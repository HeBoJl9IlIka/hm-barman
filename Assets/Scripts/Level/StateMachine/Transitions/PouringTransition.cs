using UnityEngine;

public class PouringTransition : Transition
{
    [SerializeField] private CheckingCupChoiceState _checkingCupChoiceState;

    private void Update()
    {
        NeedTransit = _checkingCupChoiceState.IsReady;
    }
}
