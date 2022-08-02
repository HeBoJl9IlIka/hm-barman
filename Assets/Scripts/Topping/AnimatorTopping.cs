using UnityEngine;

public class AnimatorTopping : MonoBehaviour
{
    [SerializeField] private SelectingTopping _selectingTopping;

    private const string MovingDown = "MovingDown";

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _selectingTopping.Selected += OnSelected;
    }

    private void OnDisable()
    {
        _selectingTopping.Selected -= OnSelected;
    }

    private void OnSelected(Topping topping)
    {
        _animator.SetTrigger(MovingDown);
    }
}
