using UnityEngine;

public class PouringTransition : Transition
{
    [SerializeField] private CheckCupChoiceState _checkCupChoiceState;

    private void Update()
    {
        NeedTransit = _checkCupChoiceState.IsReady;
    }
}
