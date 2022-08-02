using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerInterface : MonoBehaviour
{
    [SerializeField] private ShakerLayers _shakerLayers;
    [SerializeField] private ShakerClosingState _shakerClosingState;
    [SerializeField] private MixedState _mixedState;
    [SerializeField] private ButtonSelectingCup[] _buttonsSelectingCup;
    [SerializeField] private SelectingCupState _selectingCupState;
    [SerializeField] private PouringState _pouringState;
    [SerializeField] private SelectingTopping[] _selectingToppings;
    [SerializeField] private MovingCupState _movingCupState;
    [SerializeField] private LaunchingCupState _launchingCupState;
    [SerializeField] private LevelProgress _level;
    [SerializeField] private Slider _slider;
    [SerializeField] private AnimatorBackground _animatorBackground;
    [SerializeField] private float _sliderValueChangeDuration;

    public event UnityAction PouredShaker;
    public event UnityAction Mixed;
    public event UnityAction SelectedTopping;

    [SerializeField] private UnityEvent _pouredShaker;
    [SerializeField] private UnityEvent _closed;
    [SerializeField] private UnityEvent _mixed;
    [SerializeField] private UnityEvent _buttonSelectingCupPressed;
    [SerializeField] private UnityEvent _selectedCup;
    [SerializeField] private UnityEvent _pouredCup;
    [SerializeField] private UnityEvent _selectedTopping;
    [SerializeField] private UnityEvent _movingCup;
    [SerializeField] private UnityEvent _launchingCup;
    [SerializeField] private UnityEvent _launchedCup;

    private void OnEnable()
    {
        _shakerLayers.Poured += OnPouredShaker;
        _shakerClosingState.Closed += OnClosed;
        _mixedState.Mixed += OnMixed;

        foreach (var button in _buttonsSelectingCup)
        {
            button.Pressed += OnPressed;
        }

        _selectingCupState.Selected += OnSelectedCup;
        _pouringState.Poured += OnPouredCup;

        foreach (var topping in _selectingToppings)
        {
            topping.Selected += OnSelectedTopping;
        }

        _movingCupState.Moving += OnMoving;
        _launchingCupState.Launching += OnLaunching;
        _launchingCupState.Launched += OnLaunched;
        _level.Progressed += OnProgressed;
    }

    private void OnDisable()
    {
        _shakerLayers.Poured -= OnPouredShaker;
        _shakerClosingState.Closed -= OnClosed;
        _mixedState.Mixed -= OnMixed;

        foreach (var button in _buttonsSelectingCup)
        {
            button.Pressed += OnPressed;
        }

        _selectingCupState.Selected -= OnSelectedCup;
        _pouringState.Poured -= OnPouredCup;

        foreach (var topping in _selectingToppings)
        {
            topping.Selected -= OnSelectedTopping;
        }

        _movingCupState.Moving -= OnMoving;
        _launchingCupState.Launching -= OnLaunching;
        _launchingCupState.Launched -= OnLaunched;
        _level.Progressed -= OnProgressed;
    }

    private void OnPouredShaker()
    {
        PouredShaker?.Invoke();
        _pouredShaker?.Invoke();
    }

    private void OnClosed()
    {
        _closed?.Invoke();
    }

    private void OnMixed()
    {
        Mixed?.Invoke();
        _mixed?.Invoke();
    }

    private void OnPressed(Cup cup)
    {
        _buttonSelectingCupPressed?.Invoke();
    }

    private void OnSelectedCup()
    {
        _selectedCup?.Invoke();
    }

    private void OnPouredCup()
    {
        _pouredCup?.Invoke();
    }

    private void OnSelectedTopping(Topping topping)
    {
        SelectedTopping?.Invoke();
        _selectedTopping?.Invoke();
    }

    private void OnMoving()
    {
        _movingCup?.Invoke();
        _animatorBackground.Hide();
    }

    private void OnLaunching()
    {
        _launchingCup?.Invoke();
    }

    private void OnLaunched()
    {
        _launchedCup?.Invoke();
    }

    private void OnProgressed(float progress)
    {
        _slider.DOValue(progress, _sliderValueChangeDuration);
    }
}
