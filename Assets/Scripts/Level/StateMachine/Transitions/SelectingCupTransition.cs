using UnityEngine;

public class SelectingCupTransition : Transition
{
    [SerializeField] private MixedState _mixedState;

    private void Update()
    {
        NeedTransit = _mixedState.IsMixed;
    }
}
