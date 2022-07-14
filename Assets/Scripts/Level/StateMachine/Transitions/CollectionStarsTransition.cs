using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionStarsTransition : Transition
{
    [SerializeField] private GiftOpeningState _giftOpeningState;

    private void Update()
    {
        NeedTransit = _giftOpeningState.IsReady;
    }
}
