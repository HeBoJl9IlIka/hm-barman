using UnityEngine;

public class CheckCupChoiceTransition : Transition
{
    [SerializeField] private SelectingCupState _selectingCupState;

    private void Update()
    {
        NeedTransit = _selectingCupState.IsSelected;
    }
}
