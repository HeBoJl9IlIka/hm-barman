using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class MovingCupState : State
{
    [SerializeField] private SelectingCupState _selectingCupState;
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private Vector3 _targetRotation;
    [SerializeField] private Vector3 _defaultRotation;
    [SerializeField] private float _durationMove;
    [SerializeField] private float _durationRotate;

    private Cup _cup;

    public bool IsReady => _cup.transform.position == _targetPosition.position;

    public event UnityAction Moving;

    private void OnEnable()
    {
        _cup = _selectingCupState.Cup;
        Moving?.Invoke();

        Animator animator = _cup.GetComponent<Animator>();
        animator.enabled = false;

        Sequence sequence = DOTween.Sequence();

        sequence.Append(_cup.transform.DOMove(_targetPosition.position, _durationMove));
        sequence.Append(_cup.transform.DORotate(_targetRotation, _durationRotate));
        sequence.Append(_cup.transform.DORotate(_defaultRotation, _durationRotate));
    }
}
