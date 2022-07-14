using LiquidVolumeFX;
using System.Collections;
using UnityEngine;

public class AnimatorDrink : MonoBehaviour
{
    [SerializeField] private LiquidVolume _liquidVolume;
    [SerializeField] private ContainerFillingState _containerFilling;
    [SerializeField] private MixedState _mixedState;
    [SerializeField] private float _riseTime;
    [SerializeField] private float _defaultMultiplier;
    [SerializeField] private float _mixedMultiplier;

    private Coroutine _currentCoroutine;
    private float _multiplier;
    private float _time;

    private void OnEnable()
    {
        _containerFilling.Pouring += OnPouring;
        _containerFilling.Stopped += OnStopping;
        _containerFilling.Poured += OnStopping;

        _mixedState.Moving += OnMoving;
        _mixedState.Stopped += OnStopping;
        _mixedState.Mixed += OnStopping;
    }

    private void OnDisable()
    {
        _containerFilling.Pouring -= OnPouring;
        _containerFilling.Stopped -= OnStopping;
        _containerFilling.Poured -= OnStopping;

        _mixedState.Moving -= OnMoving;
        _mixedState.Stopped -= OnStopping;
        _mixedState.Mixed -= OnStopping;
    }

    private void OnMoving()
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(Play(_mixedMultiplier));
    }

    private void OnPouring()
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(Play());
    }

    private void OnStopping()
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(Stop());
    }

    private IEnumerator Play()
    {
        _multiplier = _defaultMultiplier;

        while (_time < _riseTime)
        {
            _time += Time.deltaTime;

            _liquidVolume.turbulence1 = _time * _multiplier;
            _liquidVolume.turbulence2 = _time * _multiplier;

            yield return null;
        }
    }

    private IEnumerator Play(float multiplier)
    {
        _multiplier = multiplier;

        while (_time < _riseTime)
        {
            _time += Time.deltaTime;

            _liquidVolume.turbulence1 = _time * _multiplier;
            _liquidVolume.turbulence2 = _time * _multiplier;

            yield return null;
        }
    }

    private IEnumerator Stop()
    {
        while (_time > 0)
        {
            _time -= Time.deltaTime;

            _liquidVolume.turbulence1 = _time * _multiplier;
            _liquidVolume.turbulence2 = _time * _multiplier;

            yield return null;
        }
    }
}
