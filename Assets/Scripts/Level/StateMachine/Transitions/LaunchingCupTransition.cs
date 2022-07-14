using UnityEngine;

public class LaunchingCupTransition : Transition
{
    [SerializeField] private MoveCocktailState _moveCocktailState;

    private void Update()
    {
        NeedTransit = _moveCocktailState.IsMoved;
    }
}
