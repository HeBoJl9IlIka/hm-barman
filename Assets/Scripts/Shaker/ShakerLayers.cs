using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LiquidVolumeFX;
using UnityEngine.Events;

public class ShakerLayers : MonoBehaviour
{
    private const float SpeedFilling = 0.005f;
    private const float TargetLevel = 0.9f;
    private const float Delay = 1;
    private const float MaxAmountMixingLayer = 0.02f;
    private const float MinAmountMixingLayer = 0;
    private const float AmountStep = 0.001f;

    [SerializeField] private ShakerFillingState _shakerFillingState;
    [SerializeField] private LiquidVolume _liquidVolume;
    [SerializeField] private LiquidVolume.LiquidLayer _mixingLayer;

    private Coroutine _currentCoroutine;
    private LiquidVolume.LiquidLayer _currentLayer;
    private List<LiquidVolume.LiquidLayer> _layers;
    private Color _lastColorDrink;
    private int _numberCurrentLayer;
    private int _numberMixingLayers;
    private float _delayTime;

    public LiquidVolume.LiquidLayer[] Layers => _layers.ToArray();
    public float CurrentPositionDrink => _liquidVolume.liquidSurfaceYPosition;

    private bool _isFilled => _liquidVolume.level >= TargetLevel;

    public event UnityAction Pouring;
    public event UnityAction Poured;
    public event UnityAction<float> Filled;

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

        if (_shakerFillingState.IsPour == false)
            return;

        if (_delayTime > 0)
        {
            _delayTime -= Time.deltaTime;
        }
        else
        {
            _liquidVolume.liquidLayers[_numberCurrentLayer].amount += SpeedFilling;
            _liquidVolume.UpdateLayers();

            if (_currentCoroutine != null)
                StopCoroutine(_currentCoroutine);

            if(_liquidVolume.liquidLayers[_numberMixingLayers].amount < MaxAmountMixingLayer)
                _liquidVolume.liquidLayers[_numberMixingLayers].amount += AmountStep;

            Pouring?.Invoke();
            Filled?.Invoke(_liquidVolume.level);
        }
    }

    private void OnEnable()
    {
        _shakerFillingState.Pouring += OnPouring;
        _shakerFillingState.Stopped += OnStopped;
    }

    private void OnDisable()
    {
        _shakerFillingState.Pouring -= OnPouring;
        _shakerFillingState.Stopped -= OnStopped;
    }

    private void OnPouring()
    {
        TryCreateNewLayer();
    }

    private void OnStopped()
    {
        Stop();
    }

    private void Stop()
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(HideMixingLayer());

        _delayTime = Delay;
        _lastColorDrink = _shakerFillingState.Drink.Color;

        SaveCurrentLayer();

        if (_isFilled)
        {
            Poured?.Invoke();
            enabled = false;
        }
    }

    private void TryCreateNewLayer()
    {
        if (_lastColorDrink != _shakerFillingState.Drink.Color)
        {
            Color drinkColor = _shakerFillingState.Drink.Color;
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