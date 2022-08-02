using UnityEngine;

public class MixedTransition : Transition
{
    [SerializeField] private ShakerClosingState _shakerClosingState;

    private void Update()
    {
        NeedTransit = _shakerClosingState.IsReady;
    }
}
