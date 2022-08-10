using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorBigStar : MonoBehaviour
{
    private const string Active = "Active";

    [SerializeField] private GameObject _particleSystem;

    [SerializeField] private Animator _animator;

    public bool IsActive { get; private set; }

    public void Activate()
    {
        IsActive = true;
        _animator.SetTrigger(Active);
        _particleSystem.SetActive(IsActive);
    }
}
