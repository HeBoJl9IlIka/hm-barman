using UnityEngine;

public class CheckingCupChoiceTransition : Transition
{
    [SerializeField] private SelectingCupState _selectingCupState;

    private void Update()
    {
        NeedTransit = _selectingCupState.IsReady;
    }
}
