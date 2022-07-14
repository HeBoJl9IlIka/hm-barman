using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckChoisToppingsState : State
{
    [SerializeField] private SelectingToppingState _selectingToppingState;
    [SerializeField] private Tasks _tasks;

    public bool IsReady { get; private set; }

    public event UnityAction Completed;

    private void OnEnable()
    {
        if (_selectingToppingState.Topping.Type == _tasks.Topping.Type)
            Completed?.Invoke();

        IsReady = true;
    }
}
