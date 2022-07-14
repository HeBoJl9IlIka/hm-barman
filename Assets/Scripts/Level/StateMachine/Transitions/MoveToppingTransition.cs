using UnityEngine;

public class MoveToppingTransition : Transition
{
    [SerializeField] private CheckChoisToppingsState _checkChoisToppingsState;

    private void Update()
    {
        NeedTransit = _checkChoisToppingsState.IsReady;
    }
}
