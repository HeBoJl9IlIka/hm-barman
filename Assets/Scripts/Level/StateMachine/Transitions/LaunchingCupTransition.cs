using UnityEngine;

public class LaunchingCupTransition : Transition
{
    [SerializeField] private MovingCupState _movingCupState;

    private void Update()
    {
        NeedTransit = _movingCupState.IsReady;
    }
}
