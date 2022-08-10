using UnityEngine;

public class MixingTransition : Transition
{
    [SerializeField] private ShakerClosingState _shakerClosingState;

    private void Update()
    {
        NeedTransit = _shakerClosingState.IsReady;
    }
}
