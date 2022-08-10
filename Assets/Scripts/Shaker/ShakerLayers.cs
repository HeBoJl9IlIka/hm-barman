using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LiquidVolumeFX;
using UnityEngine.Events;

public class ShakerLayers : MonoBehaviour
{
    private const float SpeedFilling = 0.25f;
    private const float TargetLevel = 0.9f;
    private const float Delay = 1;
    private const float MaxAmountMixingLayer = 0.02f;
    private const float MinAmountMixingLayer = 0;
    private const float AmountStep = 0.001f;

    [SerializeField] private LiquidVolume _liquidVolume;
    [SerializeField] private LiquidVolume.LiquidLayer _mixingLayer;
    [SerializeField] private ButtonPouring[] _buttonsPouring;

    private Drink _drink;
    private Coroutine _currentCoroutine;
    private LiquidVolume.LiquidLayer _currentLayer;
    private List<LiquidVolume.LiquidLayer> _layers;
    private Color _lastColorDrink;
    private int _numberCurrentLayer;
    private int _numberMixingLayers;
    private float _delayTime;
    private bool _isPour;

    public LiquidVolume.LiquidLayer[] Layers => _layers.ToArray();
    public float CurrentPositionDrink => _liquidVolume.liquidSurfaceYPosition;

    private bool _isFilled => _liquidVolume.level >= TargetLevel;

    public event UnityAction Pouring;
    public event UnityAction Stopped;
    public event UnityAction Poured;
    public event UnityAction<float> Filling;

    private void Start()
    {
        _layers = new List<LiquidVolume.LiquidLayer>();
        _layers.Add(_mixingLayer);
        _delayTime = Delay;
    }

    private void Update()
    {
        if (_isFilled)
        {
            Stop();
            return;
        }

        if (_isPour == false)
            return;

        if (_delayTime > 0)
        {
            _delayTime -= UnityEngine.Time.deltaTime;
        }
        else
        {
            _liquidVolume.liquidLayers[_numberCurrentLayer].amount += SpeedFilling * UnityEngine.Time.deltaTime;
            _liquidVolume.UpdateLayers();

            if(_liquidVolume.liquidLayers[_numberMixingLayers].amount < MaxAmountMixingLayer)
                _liquidVolume.liquidLayers[_numberMixingLayers].amount += AmountStep;

                Pouring?.Invoke();
            Filling?.Invoke(_liquidVolume.level);
        }
    }

    private void OnEnable()
    {
        foreach (var button in _buttonsPouring)
        {
            button.Pressed += OnPressed;
            button.Released += OnReleased;
        }
    }

    private void OnDisable()
    {
        foreach (var button in _buttonsPouring)
        {
            button.Pressed -= OnPressed;
            button.Released -= OnReleased;
        }
    }

    private void OnPressed(Drink drink)
    {
        _drink = drink;
        _isPour = true;
        TryCreateNewLayer();
    }

    private void OnReleased()
    {
        _isPour = false;
        Stop();
    }

    private void Stop()
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(HideMixingLayer());

        Stopped?.Invoke();

        _delayTime = Delay;
        _lastColorDrink = _drink.Color;

        SaveCurrentLayer();

        if (_isFilled)
        {
            Poured?.Invoke();
            enabled = false;
        }
    }

    private void TryCreateNewLayer()
    {
        if (_lastColorDrink != _drink.Color)
        {
            Color drinkColor = _drink.Color;
            float defaultDensity = 1;
            
            Rewrite();

            if (_layers.Count > 0)
                ++_numberCurrentLayer;

            _currentLayer = new LiquidVolume.LiquidLayer();

            _currentLayer.color = drinkColor;
            _currentLayer.density = defaultDensity;

            _layers.Add(_currentLayer);

            AddLayers();
        }
    }

    private void SaveCurrentLayer()
    {
        _currentLayer.amount = _liquidVolume.liquidLayers[_numberCurrentLayer].amount;
        _layers[_numberCurrentLayer] = _currentLayer;
    }

    private void AddLayers()
    {
        _liquidVolume.liquidLayers = _layers.ToArray();
        _liquidVolume.UpdateLayers(true);
    }

    private IEnumerator HideMixingLayer()
    {
        while (_liquidVolume.liquidLayers[_numberMixingLayers].amount > MinAmountMixingLayer)
        {
            _liquidVolume.liquidLayers[_numberMixingLayers].amount -= AmountStep;
            _liquidVolume.UpdateLayers();
            yield return null;
        }
    }

    private void Rewrite()
    {
        LiquidVolume.LiquidLayer temporaryLayer;

        temporaryLayer = _layers[_numberCurrentLayer];
        _layers[_numberCurrentLayer] = _layers[_numberMixingLayers];
        _layers[_numberMixingLayers] = temporaryLayer;

        _numberMixingLayers = _numberCurrentLayer;

        AddLayers();
    }
}