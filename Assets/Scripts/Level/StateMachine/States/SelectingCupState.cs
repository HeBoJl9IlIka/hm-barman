using UnityEngine;
using UnityEngine.Events;

public class SelectingCupState : State
{
    public Cup Cup { get; private set; }
    public Drink Drink { get; private set; }
    public Transform StartPositionDrink { get; private set; }
    public Transform EndPositionDrink { get; private set; }
    public bool IsSelected { get; private set; }

    public event UnityAction<Cup> Selected;

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
