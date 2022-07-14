using UnityEngine;

public class GiftOpeningState : State
{
    [SerializeField] private GameObject _panel;

    public bool IsReady { get; private set; }

    private void OnEnable()
    {
        _panel.SetActive(true);
        //animation.Play();
    }

    public void ReportReadiness()
    {
        _panel.SetActive(false);
        IsReady = true;
    }
}
