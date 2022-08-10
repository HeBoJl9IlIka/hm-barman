using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManHeadIk : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnAnimatorIK()
    {
        if (_animator)
        {
            if (_target != null)
            {
                _animator.SetLookAtWeight(1);
                _animator.SetLookAtPosition(_target.position);
            }
        }
    }
}
