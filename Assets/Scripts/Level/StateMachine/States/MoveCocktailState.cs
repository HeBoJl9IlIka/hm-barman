using UnityEngine;
using DG.Tweening;

public class MoveCocktailState : State
{
    [SerializeField] private SelectingCupState _selectingCupState;
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private Vector3 _targetRotation;
    [SerializeField] private Vector3 _defaultRotation;
    [SerializeField] private float _durationMove;
    [SerializeField] private float _durationRotate;
    [SerializeField] private float _delayReportReadiness;

    private Cup _cup;

    public bool IsMoved { get; private set; }

    private void OnEnable()
    {
        _cup = _selectingCupState.Cup;

        Sequence sequence = DOTween.Sequence();

        sequence.Append(_cup.transform.DOMove(_targetPosition.position, _durationMove));
        sequence.Append(_cup.transform.DORotate(_targetRotation, _durationRotate));
        sequence.Append(_cup.transform.DORotate(_defaultRotation, _durationRotate));

        Invoke(nameof(ReportReadiness), _delayReportReadiness);
    }

    private void ReportReadiness()
    {
        IsMoved = true;
    }
}
