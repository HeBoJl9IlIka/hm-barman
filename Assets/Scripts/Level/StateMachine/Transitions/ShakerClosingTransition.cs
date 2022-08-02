using UnityEngine;

public class ShakerClosingTransition : Transition
{
    [SerializeField] private CheckingFillingState _checkingFillingState;

    private void Update()
    {
        NeedTransit = _checkingFillingState.IsReady;
    }
}
