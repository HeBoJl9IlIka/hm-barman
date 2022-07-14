using UnityEngine;

public class CheckChoisToppingsTransition : Transition
{
    [SerializeField] private SelectingToppingState _selectingToppingState;

    private void Update()
    {
        NeedTransit = _selectingToppingState.IsSelected;
    }
}
