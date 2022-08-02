using LiquidVolumeFX;
using UnityEngine;

[RequireComponent(typeof(LiquidVolume))]
public class Mixture : MonoBehaviour
{
    private const int _targetMixingValue = 20;
    private const int _mixingValueStep = 1;

    [SerializeField] private MixedState _mixedState;
    [SerializeField] private Color _targetColor;

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
        _liquidVolume.smoothContactSurface += _mixingValueStep;

        if (_liquidVolume.smoothContactSurface > _targetMixingValue)
        {
            for (int i = 0; i < _liquidVolume.liquidLayers.Length; i++)
            {
                _liquidVolume.liquidLayers[i].color = Color.Lerp(_liquidVolume.liquidLayers[i].color, _targetColor, Mathf.PingPong(Time.time, 1));
            }
        }

        _liquidVolume.UpdateLayers();
    }

    private void OnMixed()
    {
        gameObject.SetActive(false);
    }
}
