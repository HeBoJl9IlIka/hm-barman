using UnityEngine;

public class CheckFillingTransition : Transition
{
    [SerializeField] private ContainerFillingState _containerFillingState;

    private void Update()
    {
        NeedTransit = _containerFillingState.IsReady;
    }
}
