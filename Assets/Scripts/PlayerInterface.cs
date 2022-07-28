using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerInterface : MonoBehaviour
{
    [SerializeField] private ShakerLayers _shakerLayers;
    [SerializeField] private MixedState _mixedState;
    [SerializeField] private SelectingCupState _selectingCupState;
    [SerializeField] private PouringState _pouringState;
    [SerializeField] private SelectingToppingState _selectingToppingState;
    [SerializeField] private LevelProgress _level;
    [SerializeField] private ShakerClosingAnimationState _shakerClosingAnimationState;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _sliderValueChangeDuration;

    [SerializeField] private UnityEvent _pouredShaker;
    [SerializeField] private UnityEvent _closed;
    [SerializeField] private UnityEvent _mixed;
    [SerializeField] private UnityEvent _selectedCup;
    [SerializeField] private UnityEvent _pouredCup;
    [SerializeField] private UnityEvent _selectedTopping;

    private void OnEnable()
    {
        _shakerLayers.Poured += OnPouredShaker;
        _shakerClosingAnimationState.Closed += OnClosed;
        _mixedState.Mixed += OnMixed;
        _selectingCupState.Selected += OnSelectedCup;
        _pouringState.Poured += OnPouredCup;
        _selectingToppingState.Selected += OnSelectedTopping;
        _level.Progressed += OnProgressed;
    }

    private void OnDisable()
    {
        _shakerLayers.Poured -= OnPouredShaker;
        _shakerClosingAnimationState.Closed -= OnClosed;
        _mixedState.Mixed -= OnMixed;
        _selectingCupState.Selected -= OnSelectedCup;
        _pouringState.Poured -= OnPouredCup;
        _selectingToppingState.Selected -= OnSelectedTopping;
        _level.Progressed -= OnProgressed;
    }

    private void OnPouredShaker()
    {
        _pouredShaker?.Invoke();
    }

    private void OnClosed()
    {
        _closed?.Invoke();
    }

    private void OnMixed()
    {
        _mixed?.Invoke();
    }

    private void OnSelectedCup(Cup cup)
    {
        _selectedCup?.Invoke();
    }

    private void OnPouredCup()
    {
        _pouredCup?.Invoke();
    }

    private void OnSelectedTopping(Topping topping)
    {
        _selectedTopping?.Invoke();
    }

    private void OnProgressed(float progress)
    {
        _slider.DOValue(progress, _sliderValueChangeDuration);
    }
}
