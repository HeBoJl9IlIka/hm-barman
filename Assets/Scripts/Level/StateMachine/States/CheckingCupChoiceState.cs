using UnityEngine;
using UnityEngine.Events;

public class CheckingCupChoiceState : State
{
    [SerializeField] private SelectingCupState _selectingCupState;
    [SerializeField] private Tasks _tasks;

    public bool IsReady { get; private set; }

    public event UnityAction Completed;

    private void OnEnable()
    {
        if (_selectingCupState.Cup.Type == _tasks.Cup.Type)
            Completed?.Invoke();

        IsReady = true;
    }
}
