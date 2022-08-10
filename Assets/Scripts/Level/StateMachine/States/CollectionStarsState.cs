using UnityEngine;
using UnityEngine.Events;

public class CollectionStarsState : State
{
    private const string MoveDown = "MoveDown";

    [SerializeField] private GameObject _panel;

    public bool IsReady { get; private set; }

    public event UnityAction Showed;

    private void OnEnable()
    {
        _panel.SetActive(true);
        Showed?.Invoke();
    }

    public void ReportReadiness()
    {
        IsReady = true;
    }
}
