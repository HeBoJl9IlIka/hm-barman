using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class ShakerClosingAnimationState : State
{
    [SerializeField] private Cap _cap;
    [SerializeField] private Shaker _shaker;
    [SerializeField] private float _durationCap;
    [SerializeField] private float _durationShaker;
    [SerializeField] private float _targetScale;
    [SerializeField] private float _delayReportReadiness;
    [SerializeField] private float _delayShakeShaker;
    [SerializeField] private Transform[] _path;
    [SerializeField] private Transform _targetPositionShaker;
    [SerializeField] private Transform _defaultPositionShaker;
    [SerializeField] private Vector3 _targetRotateShaker;
    [SerializeField] private Vector3 _defaultRotateShaker;

    public bool IsClosed {get; private set;}

    public event UnityAction Closed;

    private void OnEnable()
    {
        MoveCap();
        Invoke(nameof(ShakeShaker), _delayShakeShaker);
        Invoke(nameof(ReportReadiness), _delayReportReadiness);
    }

    private void MoveCap()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(_cap.transform.DOMove(_path[0].position, _durationCap));
        sequence.Insert(0, _cap.transform.DOScale(new Vector3(_targetScale, _targetScale, _targetScale), _durationCap));

        sequence.Append(_cap.transform.DOMove(_path[1].position, _durationCap));
    }

    private void ShakeShaker()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(_shaker.transform.DOMove(_targetPositionShaker.position, _durationShaker));
        sequence.Insert(0, _shaker.transform.DORotate(_targetRotateShaker, _durationShaker));

        sequence.Append(_shaker.transform.DOMove(_defaultPositionShaker.position, _durationShaker));
        sequence.Insert(0, _shaker.transform.DORotate(_defaultRotateShaker, _durationShaker));
    }

    private void ReportReadiness()
    {
        FixPositionCap();
        Closed?.Invoke();
        IsClosed = true;
    }

    private void FixPositionCap()
    {
        _cap.transform.position = new Vector3(0, _cap.transform.position.y);
    }
}
