using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorButtonPouring : MonoBehaviour
{
    private const string Down = "Down";
    private const string Up = "Up";

    [SerializeField] private ButtonPouring _ButtonPouring;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _ButtonPouring.Pressed += OnPressed;
        _ButtonPouring.Released += OnReleased;
    }

    private void OnDisable()
    {
        _ButtonPouring.Pressed -= OnPressed;
        _ButtonPouring.Released -= OnReleased;
    }

    private void OnPressed(Drink drink)
    {
        _animator.SetTrigger(Down);
    } 
    
    private void OnReleased()
    {
        _animator.SetTrigger(Up);
    }
}
