using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftOpeningTransition : Transition
{
    [SerializeField] private LaunchingCupState _launchingCupState;

    private void Update()
    {
        NeedTransit = _launchingCupState.IsReady;
    }
}
