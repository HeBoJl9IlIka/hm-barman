using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorBackground : MonoBehaviour
{
    private const string Hiding = "Hiding";

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Hide()
    {
        _animator.SetTrigger(Hiding);
    }
}
