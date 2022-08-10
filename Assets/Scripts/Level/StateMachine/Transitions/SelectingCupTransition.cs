using UnityEngine;

public class SelectingCupTransition : Transition
{
    [SerializeField] private MixingState _mixedState;

    private void Update()
    {
        NeedTransit = _mixedState.IsReady;
    }
}
