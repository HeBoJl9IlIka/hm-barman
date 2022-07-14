using UnityEngine;
using DG.Tweening;

public class AnimatorFillingStateUI : MonoBehaviour
{
    [SerializeField] private RectTransform _task;
    [SerializeField] private RectTransform _bottle;
    [SerializeField] private GameObject _button;
    [SerializeField] private RectTransform _onePositionTask;
    [SerializeField] private RectTransform _endPositionTask;
    [SerializeField] private RectTransform _onePositionBottle;
    [SerializeField] private RectTransform _endPositionBottle;
    [SerializeField] private float _duration;

    public void MoveTask()
    {
        Sequence sequence = DOTween.Sequence();

        _task.DOAnchorPosX(_onePositionTask.position.x, _duration);
        _task.DOAnchorPosX(_endPositionTask.position.x, _duration).SetDelay(0.2f);
    }

    public void MoveBottle()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(_bottle.DOAnchorPos3DY(_onePositionBottle.position.y, _duration));
        sequence.Insert(0.2f, _bottle.DOAnchorPos3DY(_endPositionBottle.position.y, _duration));
    }

    public void HideButton()
    {
        _button.SetActive(false);
    }
}
