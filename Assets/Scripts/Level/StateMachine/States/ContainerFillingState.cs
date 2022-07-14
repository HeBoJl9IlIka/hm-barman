using System.Collections.Generic;
using UnityEngine;
using LiquidVolumeFX;
using UnityEngine.Events;

public class ContainerFillingState : State
{
    [SerializeField] private LiquidVolume _liquidVolume;
    [SerializeField] private float _speedFilling;
    [SerializeField] private float _targetLevel;
    [SerializeField] private float _delay;
    [SerializeField] private float _delayReportReadiness;

    private Drink _drink;
    private List<LiquidVolume.LiquidLayer> _layers;
    private LiquidVolume.LiquidLayer _currentLayer;
    private Color _lastColorDrink;
    private int _numberCurrentLayer;
    private float _delayTime;
    private bool _isPour;

    private bool _isFilled => _liquidVolume.level >= _targetLevel;

    public bool IsReady { get; private set; }
    public float CurrentPositionDrink => _liquidVolume.liquidSurfaceYPosition;
    public LiquidVolume.LiquidLayer[] ReadyDrink => _layers.ToArray();

    [SerializeField] private UnityEvent _poured;

    public event UnityAction Pouring;
    public event UnityAction Stopped;
    public event UnityAction Poured;
    public event UnityAction<float> Filled;

    private void Start()
    {
        _layers = new List<LiquidVolume.LiquidLayer>();
        _delayTime = _delay;
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
            _delayTime -= Time.deltaTime;
        }
        else
        {
            _liquidVolume.liquidLayers[_numberCurrentLayer].amount += _speedFilling;
            _liquidVolume.UpdateLayers();

            Filled?.Invoke(_liquidVolume.level);
            Pouring?.Invoke();
        }
    }

    public void SetDrink(Drink drink)
    {
        if (enabled == false)
            return;

        _drink = drink;
    }

    public void Pour()
    {
        _isPour = true;

        if (_lastColorDrink != _drink.Color)
        {
            if (_layers.Count > 0)
                ++_numberCurrentLayer;

            CreateLayer();
        }
    }

    public void Stop()
    {
        _isPour = false;

        Stopped?.Invoke();

        _lastColorDrink = _drink.Color;
        _delayTime = _delay;

        SaveCurrentLayer();

        if (_isFilled)
        {
            _poured?.Invoke();
            Poured?.Invoke();
            Invoke(nameof(ReportReadiness), _delayReportReadiness);
        }
    }

    private void CreateLayer()
    {
        _currentLayer = new LiquidVolume.LiquidLayer();
        Color drinkColor = _drink.Color;
        float defaultDensity = 1;

        _currentLayer.color = drinkColor;
        _currentLayer.density = defaultDensity;

        _layers.Add(_currentLayer);

        AddLayers();
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

    public void ReportReadiness()
    {
        IsReady = true;
    }
}
