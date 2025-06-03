using System;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Splines;

public class HandManager : MonoBehaviour
{
    [SerializeField] private int _maxHandSize;

    [SerializeField] private GameObject _cardPrefab;

    [SerializeField] private SplineContainer _splineContainer;

    [SerializeField] private Transform _spawnPoint;

    [SerializeField] private InputActionProperty _drawCardInputActionProperty;

    private List<GameObject> _handCardList = new List<GameObject>();

    private float _splineFloat = 1;

    private float _middleSplineFloat = 0.5f;

    private float _cardTweenDuration = 0.25f;

    private void Awake()
    {
        _drawCardInputActionProperty.action.Enable();

        _drawCardInputActionProperty.action.performed += drawCardByInput;
    }

    private void drawCardByInput(InputAction.CallbackContext obj)
    {
        drawCard();
    }

    private void drawCard()
    {
        if (_handCardList == null) return;

        int handCardListCount = _handCardList.Count;
        if (handCardListCount >= _maxHandSize) return;

        GameObject g = Instantiate(_cardPrefab, _spawnPoint.position, _spawnPoint.rotation);

        _handCardList.Add(g);

        updateCardPositions();
    }


    private void updateCardPositions()
    {
        if (_handCardList == null) return;

        int handCardListCount = _handCardList.Count;

        if (handCardListCount == 0) return;

        float cardSpacing = 1f / _maxHandSize;

        float firstCardOffsetFloat = ((handCardListCount - 1) * cardSpacing) / 2;

        float firstCardPositionFloat = _middleSplineFloat - firstCardOffsetFloat;


        //
        Spline spline = _splineContainer.Spline;

        for (int i = 0; i < handCardListCount; i++)
        {
            float p = firstCardOffsetFloat + i * cardSpacing;

            Vector3 splinePosition = spline.EvaluatePosition(p);

            Vector3 forward = spline.EvaluateTangent(p);

            Vector3 up = spline.EvaluateUpVector(p);

            Vector3 cardUp = Vector3.Cross(up, forward).normalized;

            Quaternion rotation = quaternion.LookRotation(forward, cardUp);

            _handCardList[i].transform.DOMove(splinePosition, _cardTweenDuration);
            _handCardList[i].transform.DORotateQuaternion(rotation, _cardTweenDuration);
        }
    }

}
