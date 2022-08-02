using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorTaskSelectingCup : MonoBehaviour
{
    private const string MoveRight = "MoveRight";
    private const string MoveLeft = "MoveLeft";

    [SerializeField] private PlayerInterface _playerInterface;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _playerInterface.Mixed += OnMixed;
        _playerInterface.SelectedTopping += OnSelectedTopping;
    }

    private void OnDisable()
    {
        _playerInterface.Mixed -= OnMixed;
        _playerInterface.SelectedTopping -= OnSelectedTopping;
    }

    private void OnMixed()
    {
        _animator.SetTrigger(MoveRight);
    }

    private void OnSelectedTopping()
    {
        _animator.SetTrigger(MoveLeft);
    }
}
