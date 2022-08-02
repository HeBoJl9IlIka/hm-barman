using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorBottle : MonoBehaviour
{
    private const string Down = "Down";
    private const string Up = "Up";

    [SerializeField] private ShakerLayers _shakerLayers;
    [SerializeField] private ButtonPouring _buttonPouringEventTrigger;

    private Animator _animator;

    private void Start()
    {

        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {  
        _shakerLayers.Poured += OnPoured;
        _buttonPouringEventTrigger.Pressed += OnPressed;
        _buttonPouringEventTrigger.Released += OnReleased;
    }

    private void OnDisable()
    {
        _shakerLayers.Poured -= OnPoured;
        _buttonPouringEventTrigger.Pressed -= OnPressed;
        _buttonPouringEventTrigger.Released -= OnReleased;
    }

    private void OnPressed(Drink arg0)
    {
        _animator.SetTrigger(Up);
    }

    private void OnReleased()
    {
        _animator.SetTrigger(Down);
    }
    private void OnPoured()
    {
        _animator.SetTrigger(Down);
    }
}
