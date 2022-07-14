using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FillingShakerState : State
{
    [SerializeField] private DrinkClone _drinkClone;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _endPosition;
    [SerializeField] private Transform _container;
    [SerializeField] private float _speedPour;
    [SerializeField] private float _delay;

    private Drink _drink;
   // private Drink.DrinkColor _lastColorDrink;
    private MeshRenderer _meshRenderer;
    private List<Drink> _drinks;
    private List<Material> _materials;
    private Transform _currentPosition;
    private bool _isPouring;
    private float _time;
    private float _scatter;
    private float _decreaseScale;
    private int _currentRenderQueue;

    private int _lastDrink => _drinks.Count - 1;

    public Transform CurrentPositionDrink
    {
        get
        {
            if (_drink == null)
                return _startPosition;
                
            return _drink.transform;
        }
    }
    public bool IsFilled { get; private set; }
    public IReadOnlyList<Drink> Drinks => _drinks;

    public event UnityAction Poured;

    private void Start()
    {
        _currentPosition = _startPosition;
        _drinks = new List<Drink>();
        _materials = new List<Material>();
        _scatter = 0.01f;
        _time = _delay;
        _decreaseScale = 0.001f;
        _currentRenderQueue = 3000;
    }

    private void Update()
    {
        if (_isPouring == false)
            return;

        if (_drink.transform.position.y < _endPosition.position.y)
        {
            _time -= Time.deltaTime;
            if (_time <= 0)
            {
                _drink.transform.localPosition += new Vector3(_drink.transform.position.x, _speedPour * Time.deltaTime);
            }
        }
        else
        {
            Save();
            Poured?.Invoke();
            IsFilled = true;
        }
    }

    public void Pour()
    {
        if (enabled == false)
            return;

        //if (_lastColorDrink != _drink.Color)
            --_currentRenderQueue;

        _meshRenderer.material.renderQueue = _currentRenderQueue;
        _drink.transform.position = new Vector3(_currentPosition.position.x, _currentPosition.position.y - _decreaseScale, _currentPosition.position.z);
        _isPouring = true;
    }

    public void Stop()
    {
        if (enabled == false)
            return;

        Save();

       // _lastColorDrink = _drink.Color;
        _currentPosition = _drink.transform;
        _isPouring = false;
        _time = _delay;
    }

    public void SetDrink(Drink drink)
    {
        if (enabled == false)
            return;

        _drink = drink;
        _meshRenderer = _drink.GetComponent<MeshRenderer>();
    }

    private void Save()
    {
        if (_drink.transform.localPosition.y <= _currentPosition.transform.position.y + _scatter)
            return;

       //if (_lastColorDrink != _drink.Color)
       // {
       //    _drinks.Add(GetNewCloneDrink());
            
       //     Instantiate(GetNewCloneDrink(), _container);
       // }
       // else
       // {
       //     _drinks[_lastDrink] = _drink;
       // }
    }

    private DrinkClone GetNewCloneDrink()
    {
        _materials.Add(new Material(_meshRenderer.material));
        _materials[_materials.Count - 1].renderQueue = _currentRenderQueue;

        //_drinkClone.SetDrinkColor(_drink.Color);
        _drinkClone.GetComponent<MeshRenderer>().material = _materials[_materials.Count - 1];
        _drinkClone.transform.position = _drink.transform.position;

        return _drinkClone;
    }
}
