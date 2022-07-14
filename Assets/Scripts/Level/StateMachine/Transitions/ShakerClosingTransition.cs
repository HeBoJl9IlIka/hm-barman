using UnityEngine;

public class ShakerClosingTransition : Transition
{
    [SerializeField] private CheckFillingState _checkFillingState;

    private void Update()
    {
        NeedTransit = _checkFillingState.IsReady;
    }
}
