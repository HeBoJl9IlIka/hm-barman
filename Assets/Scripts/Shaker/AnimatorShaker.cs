using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class AnimatorShaker : MonoBehaviour
{
    private const string PourOut = "PourOut";

    [SerializeField] private AnimatorCap _animatorCap;
    [SerializeField] private AnimationShakerMovement _shakerMovement;
    [SerializeField] private AnimationAmountCocktail _amountCocktail;
    [SerializeField] private SelectingCup[] _selectingCups;

    private Animator _animator;

    public bool IsClosing { get; private set; }

    public event UnityAction Closed;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (IsClosing == false)
            return;

        if (_shakerMovement.IsClosed)
        {
            Closed?.Invoke();
            IsClosing = false;
        }
    }

    private void OnEnable()
    {
        _animatorCap.Closed += OnClosed;
        
        foreach (var selectingCup in _selectingCups)
        {
            selectingCup.Selected += OnSelected;
        }
    }

    private void OnDisable()
    {
        _animatorCap.Closed -= OnClosed;

        foreach (var selectingCup in _selectingCups)
        {
            selectingCup.Selected -= OnSelected;
        }
    }

    private void OnClosed()
    {
        _shakerMovement.Play();
        IsClosing = true;
    }

    private void OnSelected()
    {
        _animator.SetTrigger(PourOut);
        _amountCocktail.Play();
    }
}
