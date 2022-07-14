using UnityEngine;

public class MixedTransition : Transition
{
    [SerializeField] private ShakerClosingAnimationState _shakerClosingAnimationState;

    private void Update()
    {
        NeedTransit = _shakerClosingAnimationState.IsClosed;
    }
}
