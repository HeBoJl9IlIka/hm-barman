using UnityEngine;
using LiquidVolumeFX;

[RequireComponent(typeof(LiquidVolume))]
public class Cocktail : MonoBehaviour
{
    private const int AlphaDefault = 1;

    [SerializeField] private MixedState _mixedState;

    private LiquidVolume _liquidVolume;

    private void Start()
    {
        _liquidVolume = GetComponent<LiquidVolume>();
    }

    private void OnEnable()
    {
        _mixedState.Mixed += OnMixed;
    }

    private void OnDisable()
    {
        _mixedState.Mixed -= OnMixed;
    }

    private void OnMixed()
    {
        _liquidVolume.alpha = AlphaDefault;
    }
}
