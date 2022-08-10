using UnityEngine;

public class MovingToppingTransition : Transition
{
    [SerializeField] private SelectingToppingState _selectingToppingState;

    private void Update()
    {
        NeedTransit = _selectingToppingState.IsReady;
    }
}
