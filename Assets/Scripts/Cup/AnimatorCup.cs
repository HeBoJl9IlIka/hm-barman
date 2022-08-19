using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent (typeof(AnimationAmountCocktailCup))]
public class AnimatorCup : MonoBehaviour
{
    [SerializeField] private SelectingCup _selectingCup;

    private const string MovingRight = "MovingRight";

    private Animator _animator;
    private AnimationAmountCocktailCup _amountCocktailCup;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _amountCocktailCup = GetComponent<AnimationAmountCocktailCup>();
    }

    private void OnEnable()
    {
        _selectingCup.Selected += OnSelected;
    }

    private void OnDisable()
    {
        _selectingCup.Selected -= OnSelected;
    }

    private void OnSelected()
    {
        _animator.SetTrigger(MovingRight);
        _amountCocktailCup.Play();
    }
}
