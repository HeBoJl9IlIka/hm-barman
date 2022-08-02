using UnityEngine;

public class MovingToppingTransition : Transition
{
    [SerializeField] private CheckingChoiceToppingsState _checkingChoiceToppingsState;

    private void Update()
    {
        NeedTransit = _checkingChoiceToppingsState.IsReady;
    }
}
