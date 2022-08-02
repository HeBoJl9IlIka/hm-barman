using DG.Tweening;
using UnityEngine;

public class AnimationCapMovement : MonoBehaviour
{
    private const float DurationCap = 0.25f;
    private const float TargetScale = 5.3f;
    private const float DurationToLastPosition = 0.1f;
    private const float DelayMoving = 0.2f;
    private const float DelayRotation = 0.3f;

    [SerializeField] private Transform[] _path;
    [SerializeField] private Vector3 _targetRotateCap;

    public bool IsClosed => transform.position == _path[_lastPoint].position;

    private int _lastPoint => _path.Length - 1;

    public void Play()
    {
        int pointNumber = 0;

        Sequence sequence = DOTween.Sequence();

        sequence.Append(transform.DOMove(_path[pointNumber++].position, DurationCap));
        sequence.Insert(0, transform.DOScale(new Vector3(TargetScale, TargetScale, TargetScale), DurationCap));
        sequence.Insert(DelayMoving, transform.DOMove(_path[pointNumber++].position, DurationCap));

        sequence.Append(transform.DOMove(_path[pointNumber].position, DurationToLastPosition));
        sequence.Insert(DelayRotation, transform.DORotate(_targetRotateCap, DurationCap));
    }
}
