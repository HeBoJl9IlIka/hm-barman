using UnityEngine;
using UnityEngine.Events;

public class SelectingToppingState : State
{
    private const float DelayReportReadiness = 1f;

    [SerializeField] private SelectingTopping[] _selectingToppings;
    [SerializeField] private SelectingCupState _selectingCupState;

    private Topping _topping;

    public Topping Topping => _topping;
    public bool IsReady { get; private set; }

    public event UnityAction Selected;

    private void OnEnable()
    {
        foreach (var topping in _selectingToppings)
        {
            topping.Selected += OnSelected;
        }
    }

    private void OnDisable()
    {
        foreach (var topping in _selectingToppings)
        {
            topping.Selected -= OnSelected;
        }
    }

    private void OnSelected(Topping topping)
    {
        Selected?.Invoke();

        _topping = topping;
        _topping.transform.SetParent(_selectingCupState.Cup.transform);
        Invoke(nameof(ReportReadiness), DelayReportReadiness);
    }

    public void ReportReadiness()
    {
        IsReady = true;
    }
}
