using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class ShakerClosingAnimationState : State
{
    private const float DurationCap = 0.25f;
    private const float DurationShaker = 0.3f;
    private const float TargetScale = 5.3f;
    private const float DelayReportReadiness = 1;
    private const float DelayShakeShaker = 0.55f;

    [SerializeField] private Cap _cap;
    [SerializeField] private Shaker _shaker;
    [SerializeField] private Transform[] _path;
    [SerializeField] private Transform _targetPositionShaker;
    [SerializeField] private Transform _defaultPositionShaker;
    [SerializeField] private Vector3 _targetRotateShaker;
    [SerializeField] private Vector3 _defaultRotateShaker;
    [SerializeField] private Vector3 _targetRotateCap;

    public bool IsClosed {get; private set;}

    public event UnityAction Closed;

    private void OnEnable()
    {
        MoveCap();
        Invoke(nameof(ShakeShaker), DelayShakeShaker);
        Invoke(nameof(ReportReadiness), DelayReportReadiness);
    }

    private void MoveCap()
    {
        int pointNumber = 0;
        float durationToLastPosition = 0.1f;
        float delayMoving = 0.2f;
        float delayRotation = 0.3f;

        Sequence sequence = DOTween.Sequence();

        sequence.Append(_cap.transform.DOMove(_path[pointNumber++].position, DurationCap));
        sequence.Insert(0, _cap.transform.DOScale(new Vector3(TargetScale, TargetScale, TargetScale), DurationCap));
        sequence.Insert(delayMoving, _cap.transform.DOMove(_path[pointNumber++].position, DurationCap));

        sequence.Append(_cap.transform.DOMove(_path[pointNumber].position, durationToLastPosition));
        sequence.Insert(delayRotation, _cap.transform.DORotate(_targetRotateCap, DurationCap));
    }

    private void ShakeShaker()
    {
        float delayRotation = 0.1f;

        Sequence sequence = DOTween.Sequence();

        sequence.Append(_shaker.transform.DOMove(_targetPositionShaker.position, DurationShaker));
        sequence.Insert(0, _shaker.transform.DORotate(_targetRotateShaker, DurationShaker));

        sequence.Append(_shaker.transform.DOMove(_defaultPositionShaker.position, DurationShaker));
        sequence.Insert(delayRotation, _shaker.transform.DORotate(_defaultRotateShaker, DurationShaker));
    }

    private void ReportReadiness()
    {
        Closed?.Invoke();
        IsClosed = true;
    }
}
