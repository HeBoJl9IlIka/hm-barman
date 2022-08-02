using UnityEngine;

public class CheckingChoiceToppingsTransition : Transition
{
    [SerializeField] private SelectingToppingState _selectingToppingState;

    private void Update()
    {
        NeedTransit = _selectingToppingState.IsReady;
    }
}
