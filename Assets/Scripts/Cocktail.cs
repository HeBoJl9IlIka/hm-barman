using UnityEngine;
using LiquidVolumeFX;

[RequireComponent(typeof(LiquidVolume))]
public class Cocktail : MonoBehaviour
{
    private const int AlphaDefault = 1;

    [SerializeField] private MixedState _mixedState;
    [SerializeField] private float _multiplierAlpha;

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
        _liquidVolume.alpha = _mixedState.MixingTime * _multiplierAlpha;
    }

    private void OnMixed()
    {
        _liquidVolume.alpha = AlphaDefault;
    }
}
