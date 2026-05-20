using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        private static Dictionary<Delegate, Action<GameAction>> _wrappedReactions = new();


        /// <summary>
        /// 启动方法
        /// </summary>
        /// <param name="action"></param>
        /// <param name="OnPerformFinished"></param>
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


        /// <summary>
        /// 想要在执行中的GameAction中 执行另一个新的GameAction使用这个方法
        /// </summary>
        /// <param name="gameAction"></param>
        public void AddReaction(GameAction gameAction)
        {
            _reactions?.Add(gameAction);
        }

        private IEnumerator flow(GameAction action, Action OnFlowFinished = null)
        {
            //执行前序方法

            //得到其他 前序GameAction
            _reactions = action.PreReactions;
            //执行当前 前序GameAction前序方法
            performSubscribers(action, _preSubs);
            //执行其他 前序GameAction方法
            yield return performReactions();


            //执行方法
            //得到其他 GameAction
            _reactions = action.PerformReactions;
            //执行当前 GameAction方法
            yield return performPerformer(action);
            //执行其他 GameAction方法
            yield return performReactions();

            //执行后序方法
            //得到其他 后序GameAction
            _reactions = action.PostReactions;
            //执行当前 后序GameAction前序方法
            performSubscribers(action, _postSubs);
            //执行当前 后序GameAction前序方法
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

            _wrappedReactions[reaction] = WrappedReaction;

            if (subs.TryGetValue(type, out var sub))
            {
                sub.Add(WrappedReaction);
                // Debug.Log($"添加注册 {type} , {timing}: -> {sub.Count}");

            }
            else
            {
                subs.Add(type, new());
                subs[type].Add(WrappedReaction);
                // Debug.Log($"添加注册 {type} , {timing}: -> {subs[type].Count}");
            }
        }

        public static void UnsubscribeReaction<T>(Action<T> reaction, ReactionTiming timing) where T : GameAction
        {
            Dictionary<Type, List<Action<GameAction>>> subs = timing == ReactionTiming.PRE ? _preSubs : _postSubs;

            Type type = typeof(T);

            if (subs.TryGetValue(type, out var sub))
            {
                if (_wrappedReactions.TryGetValue(reaction, out var wrapped))
                {
                    sub.Remove(wrapped);
                    _wrappedReactions.Remove(reaction);
                }
                // Debug.Log($"删除注册 {type} , {timing}: -> {sub.Count}");
            }
        }
    }
}