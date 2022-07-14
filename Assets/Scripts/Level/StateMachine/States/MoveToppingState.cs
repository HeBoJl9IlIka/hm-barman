using UnityEngine;
using DG.Tweening;

public class MoveToppingState : State
{
    [SerializeField] private SelectingCupState _selectingCupState;
    [SerializeField] private SelectingToppingState _selectingToppingState;
    [SerializeField] private float _duration;
    [SerializeField] private float _delay;
    [SerializeField] private float _delayReportReadiness;

    private Topping _topping;
    private Transform _startPosition;
    private Transform _endPosition;
    private Transform _cup;

    public bool IsMoved { get; private set; }

    private void Start() { }

    private void OnEnable()
    {
        _topping = _selectingToppingState.Topping;
        _startPosition = _selectingToppingState.StartPosition;
        _endPosition = _selectingToppingState.EndPosition;
        _cup = _selectingCupState.Cup.transform;

        _topping.transform.position = _startPosition.position;
        _topping.transform.DOMove(_endPosition.position, _duration).SetDelay(_delay);
        _topping.transform.SetParent(_cup, false);

        Invoke(nameof(ReportReadiness), _delayReportReadiness);
    }

    private void ReportReadiness()
    {
        IsMoved = true;
    }
}
