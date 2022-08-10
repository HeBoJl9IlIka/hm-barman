using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorSmallStar : MonoBehaviour
{
    private const string Active = "Active";

    [SerializeField] private GameObject _particleSystem;

    private Animator _animator;

    public bool IsActive { get; private set; }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Activate()
    {
        IsActive = true;
        _animator.SetTrigger(Active);
        _particleSystem.SetActive(IsActive);
    }
}
