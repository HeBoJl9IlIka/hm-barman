using UnityEngine;

public class SelectingToppingTransition : Transition
{
    [SerializeField] private PouringState _pouringState;

    private void Update()
    {
        NeedTransit = _pouringState.IsPoured;
    }
}
