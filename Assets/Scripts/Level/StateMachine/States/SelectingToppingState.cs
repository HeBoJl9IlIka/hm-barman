using UnityEngine;
using UnityEngine.Events;

public class SelectingToppingState : State
{
    public bool IsSelected { get; private set; }
    public Topping Topping { get; private set; }
    public Transform StartPosition { get; private set; }
    public Transform EndPosition { get; private set; }

    public event UnityAction<Topping> Selected;

    private void Start() { }

    public void SetTopping(Topping topping)
    {
        Topping = topping;
        Selected?.Invoke(topping);
        IsSelected = true;
    }

    public void SetStartPosition(Transform startPosition)
    {
        StartPosition = startPosition;
    }

    public void SetEndPosition(Transform endPosition)
    {
        EndPosition = endPosition;
    }
}
