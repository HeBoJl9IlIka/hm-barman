using UnityEngine;

public class CheckFillingTransition : Transition
{
    [SerializeField] private ShakerFillingState _containerFillingState;

    private void Update()
    {
        NeedTransit = _containerFillingState.IsReady;
    }
}
