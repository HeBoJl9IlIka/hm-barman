using UnityEngine;

public class MovingCupTransition : Transition
{
    [SerializeField] private MovingToppingState _movingToppingState;

    private void Update()
    {
        NeedTransit = _movingToppingState.IsReady;
    }
}
