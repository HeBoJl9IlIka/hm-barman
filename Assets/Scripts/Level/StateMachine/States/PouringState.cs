using UnityEngine;
using UnityEngine.Events;

public class PouringState : State
{
    [SerializeField] private AnimationAmountCocktailCup[] _animations;

    public bool IsReady { get; private set; }

    public event UnityAction Poured;

    private void Update()
    {
        foreach (var animation in _animations)
        {
            if (animation.IsFull)
            {
                Poured?.Invoke();
                IsReady = true;
            }
        }
    }
}
