using UnityEngine;

public class CheckingFillingTransition : Transition
{
    [SerializeField] private ShakerFillingState _shakerFillingState;

    private void Update()
    {
        NeedTransit = _shakerFillingState.IsReady;
    }
}
