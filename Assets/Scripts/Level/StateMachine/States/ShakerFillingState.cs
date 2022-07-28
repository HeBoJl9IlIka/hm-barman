using UnityEngine;
using UnityEngine.Events;

public class ShakerFillingState : State
{
    private const float _delayReportReadiness = 1;

    [SerializeField] private ShakerLayers _shakerLayers;

    public bool IsReady { get; private set; }
    public bool IsPour { get; private set; }
    public Drink Drink { get; private set; }

    public event UnityAction Pouring;
    public event UnityAction Stopped;

    [SerializeField] private UnityEvent _poured;
    
    private void Start() { }

    private void OnEnable()
    {
        _shakerLayers.Poured += OnPoured;
    }

    private void OnDisable()
    {
        _shakerLayers.Poured -= OnPoured;
    }

    public void SetDrink(Drink drink)
    {
        Drink = drink;
    }

    public void Pour()
    {
        IsPour = true;
        Pouring?.Invoke();
    }

    public void Stop()
    {
        IsPour = false;
        Stopped?.Invoke();
    }

    public void ReportReadiness()
    {
        IsReady = true;
    }

    private void OnPoured()
    {
        _poured?.Invoke();
        Invoke(nameof(ReportReadiness), _delayReportReadiness);
    }
}













////private const float _speedFilling = 0.005f;
////private const float _targetLevel = 0.9f;
////private const float _delay = 1;
//private const float _delayReportReadiness = 1;

//[SerializeField] private ShakerMixingLayer _shakerMixingLayer;
//[SerializeField] private ShakerNewLayer _shakerNewLayer;
//[SerializeField] private ShakerLayers _shakerLayers;
////[SerializeField] private LiquidVolume _liquidVolume;

//private Drink _drink;
//private List<LiquidVolume.LiquidLayer> _layers;
//private LiquidVolume.LiquidLayer _currentLayer;
//private Color _lastColorDrink;
////private float _delayTime;

//public LiquidVolume.LiquidLayer[] Layers => _layers.ToArray();
//public Color DrinkColor => _drink.Color;
//public int NumberMixingLayer { get; private set; }
//public int NumberCurrentLayer { get; private set; }
////public float CurrentPositionDrink => _liquidVolume.liquidSurfaceYPosition;
//public bool IsPour { get; private set; }
//public bool IsReady { get; private set; }
//public bool IsOtherDrink => _lastColorDrink != _drink.Color;

//private int _numberLastLayer => _layers.Count - 1;
////private bool _isFilled => _liquidVolume.level >= _targetLevel;

//public event UnityAction Pouring;
//public event UnityAction Stopped;
////public event UnityAction Poured;
////public event UnityAction<float> Filled;

////[SerializeField] private UnityEvent _poured;

//private void Start()
//{
//    _layers = new List<LiquidVolume.LiquidLayer>();
//    //_delayTime = _delay;
//    _lastColorDrink = Color.black;
//}

//private void Update()
//{
//    //if (_isFilled)
//    //{
//    //    Stop();
//    //    return;
//    //}

//    if (IsPour == false)
//        return;

//    //if (_delayTime > 0)
//    //{
//    //    _delayTime -= Time.deltaTime;
//    //}
//    //else
//    //{
//    //    _liquidVolume.liquidLayers[_numberCurrentLayer].amount += _speedFilling;
//    //    _liquidVolume.UpdateLayers();

//    //    Filled?.Invoke(_liquidVolume.level);
//    //}
//}

//private void OnEnable()
//{
//    _shakerMixingLayer.Created += OnCreated;
//    _shakerNewLayer.Created += OnCreated;
//}

//private void OnDisable()
//{
//    _shakerMixingLayer.Created -= OnCreated;
//    _shakerNewLayer.Created -= OnCreated;
//}

//public void SetDrink(Drink drink)
//{
//    if (enabled == false)
//        return;

//    _drink = drink;
//}

//public void Pour()
//{
//    IsPour = true;

//    Pouring?.Invoke();
//}

//public void Stop()
//{
//    IsPour = false;

//    Stopped?.Invoke();

//    _lastColorDrink = _drink.Color;
//    //_delayTime = _delay;

//    SaveCurrentLayer();

//    //Invoke(nameof(ReportReadiness), _delayReportReadiness);

//    //if (_isFilled)
//    //{
//    //    _poured?.Invoke();
//    //    Poured?.Invoke();
//    //}
//}

//public void ReportReadiness()
//{
//    IsReady = true;

//    foreach (var layer in _layers)
//    {
//        Debug.Log(layer.amount);
//    }
//}

//private void SaveCurrentLayer()
//{
//    //_currentLayer.amount = _liquidVolume.liquidLayers[NumberCurrentLayer].amount;
//    Debug.Log(_layers.Count + " - LayersCount");
//    Debug.Log(NumberCurrentLayer + " - NumberCurrentLayer");
//    _layers[NumberCurrentLayer] = _shakerLayers.CurrentLayer;
//}

////private void AddLayers()
////{
////    _liquidVolume.liquidLayers = Layers;
////    _liquidVolume.UpdateLayers(true);
////}

//private void OnCreated(LiquidVolume.LiquidLayer layer, bool mixingLayer)
//{
//    if (mixingLayer)
//    {
//        _layers.Add(layer);
//        //AddLayers();

//        NumberMixingLayer = _numberLastLayer;
//        Debug.Log("OnCreated mixingLayer " + NumberMixingLayer);
//    }
//    else
//    {
//        //_currentLayer = layer;
//        _layers.Add(layer);
//        //AddLayers();

//        NumberCurrentLayer = _numberLastLayer;
//        Debug.Log("OnCreated newLayer " + NumberCurrentLayer);
//    }
//}