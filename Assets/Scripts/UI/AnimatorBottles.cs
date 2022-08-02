using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorBottles : MonoBehaviour
{
    private const string Moving = "Moving";

    [SerializeField] private PlayerInterface _playerInterface;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _playerInterface.PouredShaker += OnPouredShaker;
    }

    private void OnDisable()
    {
        _playerInterface.PouredShaker -= OnPouredShaker;
    }

    private void OnPouredShaker()
    {
        _animator.SetTrigger(Moving);
    }
}
