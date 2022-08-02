using System;
using UnityEngine;
using UnityEngine.Events;

public class ShakerClosingState : State
{
    private const float DelayReportReadiness = 0.5f;

    [SerializeField] private AnimatorCap _animatorCap;

    public bool IsReady {get; private set;}

    public event UnityAction Closing;
    public event UnityAction Closed;

    private void Start() { }

    private void OnEnable()
    {
        Closing?.Invoke();
        _animatorCap.Closed += OnClosed;
    }

    private void OnDisable()
    {
        _animatorCap.Closed -= OnClosed;
    }

    private void OnClosed()
    {
        Invoke(nameof(ReportReadiness), DelayReportReadiness);
    }

    private void ReportReadiness()
    {
        Closed?.Invoke();
        IsReady = true;
    }
}
