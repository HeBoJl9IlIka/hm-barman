using UnityEngine;
using UnityEngine.Events;

public class MixedState : State
{
    private const float DelayReportReadiness = 1;
    private const string Mixing = "Mixing";
    private const string Stopping = "Stopping";

    [SerializeField] private Animator _animator;
    [SerializeField] private float _targetMixingTime;

    private bool _isMixing;

    private bool _isMixed => MixingTime >= _targetMixingTime;

    public float MixingTime { get; private set; }
    public bool IsReady { get; private set; }

    public event UnityAction Moving;
    public event UnityAction Stopped;
    public event UnityAction Mixed;

    private void Update()
    {
        if (_isMixed)
        {
            Stop();
            return;
        }
        
        if (_isMixing)
        {
            MixingTime += Time.deltaTime;
            Moving?.Invoke();
        }
    }

    private void OnEnable()
    {
        _animator.enabled = true;
    }

    public void Mix()
    {
        _isMixing = true;
        _animator.SetTrigger(Mixing);
    }

    public void Stop()
    {
        _isMixing = false;
        _animator.SetTrigger(Stopping);
        Stopped?.Invoke();

        if (_isMixed)
        {
            Mixed?.Invoke();
            Invoke(nameof(ReportReadiness), DelayReportReadiness);
        }
    }

    public void ReportReadiness()
    {
        IsReady = true;
    }
}