using UnityEngine;
using UnityEngine.Events;

public class SelectingCupState : State
{
    public event UnityAction<Cup> Selected;

    public bool IsSelected { get; private set; }
    public Cup Cup { get; private set; }
    public Drink Drink { get; private set; }
    public Transform StartPositionDrink { get; private set; }
    public Transform EndPositionDrink { get; private set; }

    private void Start() { }
    
    public void SetCup(Cup cup)
    {
        Cup = cup;
        Selected?.Invoke(cup);
        IsSelected = true;
    }

    public void SetDrink(Drink drink)
    {
        Drink = drink;
    }

    public void SetStartPosition(Transform startPosition)
    {
        StartPositionDrink = startPosition;
    }

    public void SetEndPosition(Transform endPosition)
    {
        EndPositionDrink = endPosition;
    }
}
