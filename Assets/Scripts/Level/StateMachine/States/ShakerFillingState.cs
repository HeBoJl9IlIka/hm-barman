using UnityEngine;

public class ShakerFillingState : State
{
    private const float _delayReportReadiness = 1f;

    [SerializeField] private ShakerLayers _shakerLayers;

    public bool IsReady { get; private set; }

    private void Start() { }

    private void OnEnable()
    {
        _shakerLayers.Poured += OnPoured;
    }

    private void OnDisable()
    {
        _shakerLayers.Poured -= OnPoured;
    }

    private void OnPoured()
    {
        Invoke(nameof(ReportReadiness), _delayReportReadiness);
    }

    private void ReportReadiness()
    {
        IsReady = true;
    }
}