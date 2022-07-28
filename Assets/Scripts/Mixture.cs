using LiquidVolumeFX;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LiquidVolume))]
public class Mixture : MonoBehaviour
{
    [SerializeField] private MixedState _mixedState;

    private LiquidVolume _liquidVolume;

    private void Start()
    {
        _liquidVolume = GetComponent<LiquidVolume>();
    }

    private void OnEnable()
    {
        _mixedState.Moving += OnMoving;
        _mixedState.Mixed += OnMixed;
    }

    private void OnDisable()
    {
        _mixedState.Moving -= OnMoving;
        _mixedState.Mixed -= OnMixed;
    }

    private void OnMoving()
    {
        _liquidVolume.smoothContactSurface += (int)_mixedState.MixingTime;
    }

    private void OnMixed()
    {
        _liquidVolume.alpha = 0;
    }
}
