using UnityEngine;

public class ShakerClosingTransition : Transition
{
    [SerializeField] private ShakerFillingState _shakerFillingState;

    private void Update()
    {
        NeedTransit = _shakerFillingState.IsReady;
    }
}
