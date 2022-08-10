using UnityEngine;

public class PouringTransition : Transition
{
    [SerializeField] private SelectingCupState _selectingCupState;

    private void Update()
    {
        NeedTransit = _selectingCupState.IsReady;
    }
}
