using System;
using System.Collections;
using System.Collections.Generic;

namespace General.ActionSystemComponents
{
    public class ActionSystem : General.Singleton<ActionSystem>
    {
        private List<GameAction> _reactions = null;

        public bool IsPerforming { get; private set; } = false;

        //Before Performers
        private static Dictionary<Type, List<Action<GameAction>>> _preSubs = new();

        //After Performers
        private static Dictionary<Type, List<Action<GameAction>>> _postSubs = new();

        //Type Attach Performer
        private static Dictionary<Type, Func<GameAction, IEnumerator>> _performers = new();

        public void Perform(GameAction action, Action OnPerformFinished = null)
        {
            if (IsPerforming)
            {
                return;
            }

            IsPerforming = true;

            StartCoroutine(flow(action, () =>
            {
                IsPerforming = false;
                OnPerformFinished?.Invoke();
            }));
        }

        public void AddReaction(GameAction gameAction)
        {
            _reactions?.Add(gameAction);
        }

        private IEnumerator flow(GameAction action, Action OnFlowFinished = null)
        {
            _reactions = action.PreReactions;
            performSubscribers(action, _preSubs);
            yield return performReactions();


            _reactions = action.PerformReactions;
            yield return performPerformer(action);
            yield return performReactions();


            _reactions = action.PostReactions;
            performSubscribers(action, _postSubs);
            yield return performReactions();

            OnFlowFinished?.Invoke();
        }

        private void performSubscribers(GameAction action, Dictionary<Type, List<Action<GameAction>>> subs)
        {
            Type type = action.GetType();

            if (subs.TryGetValue(type, out var subPerformerList))
            {
                foreach (Action<GameAction> subPerformer in subPerformerList)
                {
                    subPerformer(action);
                }
            }
        }

        private IEnumerator performPerformer(GameAction action)
        {
            Type type = action.GetType();

            if (_performers.TryGetValue(type, out var performer))
            {
                yield return performer(action);
            }
        }

        private IEnumerator performReactions()
        {
            foreach (GameAction gameAction in _reactions)
            {
                yield return flow(gameAction);
            }
        }


        public static void AttachPerformer<T>(Func<T, IEnumerator> performer) where T : GameAction
        {
            Type type = typeof(T);

            IEnumerator WrappedPerformer(GameAction action) => performer((T)action);

            if (_performers.ContainsKey(type))
            {
                _performers[type] = WrappedPerformer;
            }
            else
            {
                _performers.Add(type, WrappedPerformer);
            }
        }

        public static void DetachPerformer<T>() where T : GameAction
        {
            Type type = typeof(T);

            if (_performers.ContainsKey(type))
            {
                _performers.Remove(type);
            }
        }

        public static void SubscribeReaction<T>(Action<T> reaction, ReactionTiming timing) where T : GameAction
        {
            Dictionary<Type, List<Action<GameAction>>> subs = timing == ReactionTiming.PRE ? _preSubs : _postSubs;

            void WrappedReaction(GameAction action) => reaction((T)action);

            Type type = typeof(T);

            if (subs.TryGetValue(type, out var sub))
            {
                sub.Add(WrappedReaction);
            }
            else
            {
                subs.Add(type, new());
                subs[type].Add(WrappedReaction);
            }
        }

        public static void UnsubscribeReaction<T>(Action<T> reaction, ReactionTiming timing) where T : GameAction
        {
            Dictionary<Type, List<Action<GameAction>>> subs = timing == ReactionTiming.PRE ? _preSubs : _postSubs;

            Type type = typeof(T);

            if (subs.TryGetValue(type, out var sub))
            {
                void WrappedReaction(GameAction action) => reaction((T)action);

                sub.Remove(WrappedReaction);
            }
        }
    }
}