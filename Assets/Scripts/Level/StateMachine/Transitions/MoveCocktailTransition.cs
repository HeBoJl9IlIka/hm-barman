using UnityEngine;

public class MoveCocktailTransition : Transition
{
    [SerializeField] private MoveToppingState _moveToppingState;

    private void Update()
    {
        NeedTransit = _moveToppingState.IsMoved;
    }
}
