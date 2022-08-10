using UnityEngine;
using UnityEngine.Events;

public class GiftOpeningState : State
{
    [SerializeField] private GameObject _panel;

    public bool IsReady { get; private set; }

    public event UnityAction Showed;

    private void OnEnable()
    {
        Showed?.Invoke();
        _panel.SetActive(true);
    }

    public void ReportReadiness()
    {
        _panel.SetActive(false);
        IsReady = true;
    }
}
