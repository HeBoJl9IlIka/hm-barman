using LiquidVolumeFX;
using System.Collections;
using UnityEngine;

public class AnimatorDrink : MonoBehaviour
{
    private const float PourMultiplier = 0.3f;
    private const float MixedMultiplier = 1f;
    private const float Duration = 1;

    [SerializeField] private LiquidVolume _liquidVolume;
    [SerializeField] private ShakerLayers _shakerLayers;
    [SerializeField] private MixedState _mixedState;

    private Coroutine _currentCoroutine;
    private float _time;

    private void OnEnable()
    {
        _shakerLayers.Pouring += OnPouring;
        _shakerLayers.Stopped += OnStopped;
        _shakerLayers.Poured += OnStopped;
        _mixedState.Moving += OnMoving;
        _mixedState.Stopped += OnStopped;
        _mixedState.Mixed += OnStopped;
    }

    private void OnDisable()
    {
        _shakerLayers.Pouring -= OnPouring;
        _shakerLayers.Stopped -= OnStopped;
        _shakerLayers.Poured -= OnStopped;
        _mixedState.Moving -= OnMoving;
        _mixedState.Stopped -= OnStopped;
        _mixedState.Mixed -= OnStopped;
    }

    private void OnMoving()
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(Play(MixedMultiplier));
    }

    private void OnPouring()
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(Play(PourMultiplier));
    }

    private void OnStopped()
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(Stop());
    }

    private IEnumerator Play(float multiplier)
    {
        while (_time < Duration)
        {
            _time += Time.deltaTime;

            _liquidVolume.turbulence1 = _time * multiplier;
            _liquidVolume.turbulence2 = _time * multiplier;

            yield return null;
        }
    }

    private IEnumerator Stop()
    {
        while (_time > 0)
        {
            _time -= Time.deltaTime;

            _liquidVolume.turbulence1 = _time * PourMultiplier;
            _liquidVolume.turbulence2 = _time * PourMultiplier;

            yield return null;
        }
    }
}
