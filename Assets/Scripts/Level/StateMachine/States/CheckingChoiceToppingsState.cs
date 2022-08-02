using UnityEngine;
using UnityEngine.Events;

public class CheckingChoiceToppingsState : State
{
    [SerializeField] private SelectingToppingState _selectingToppingState;
    [SerializeField] private Tasks _tasks;

    public bool IsReady { get; private set; }

    public event UnityAction Completed;

    private void OnEnable()
    {
        if (_selectingToppingState.Topping == _tasks.Topping)
            Completed?.Invoke();

        IsReady = true;
    }
}
