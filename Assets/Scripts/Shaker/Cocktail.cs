using UnityEngine;
using LiquidVolumeFX;

[RequireComponent(typeof(LiquidVolume))]
public class Cocktail : MonoBehaviour
{
    private const int AlphaDefault = 1;

    [SerializeField] private MixingState _mixingState;

    private LiquidVolume _liquidVolume;

    private void Start()
    {
        _liquidVolume = GetComponent<LiquidVolume>();
    }

    private void OnEnable()
    {
        _mixingState.Mixed += OnMixed;
    }

    private void OnDisable()
    {
        _mixingState.Mixed -= OnMixed;
    }

    private void OnMixed()
    {
        _liquidVolume.alpha = AlphaDefault;
    }
}
