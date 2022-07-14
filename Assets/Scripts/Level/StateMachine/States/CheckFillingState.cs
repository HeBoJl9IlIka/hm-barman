using UnityEngine;
using UnityEngine.Events;

public class CheckFillingState : State
{
    [SerializeField] private ContainerFillingState _containerFillingState;
    [SerializeField] private Tasks _task;

    public bool IsReady { get; private set; }

    [SerializeField] private UnityEvent _ready;

    public event UnityAction Completed;

    private void OnEnable()
    {
        if (_containerFillingState.ReadyDrink.Length == _task.Drinks.Count)
        {
            for (int i = 0; i < _task.Drinks.Count; i++)
            {
                if (_containerFillingState.ReadyDrink[i].color == _task.Drinks[i].color)
                {
                    if (_containerFillingState.ReadyDrink[i].amount > _task.Drinks[i].amount + _task.Dispersion)
                    {
                        IsReady = true;
                        _ready?.Invoke();
                        return;
                    }

                    if (_containerFillingState.ReadyDrink[i].amount < _task.Drinks[i].amount - _task.Dispersion)
                    {
                        IsReady = true;
                        _ready?.Invoke();
                        return;
                    }
                }
                else
                {
                    IsReady = true;
                    _ready?.Invoke();
                    return;
                }
            }
        }
        else
        {
            IsReady = true;
            _ready?.Invoke();
            return;
        }

        _ready?.Invoke();
        Completed?.Invoke();
        IsReady = true;
    }
}