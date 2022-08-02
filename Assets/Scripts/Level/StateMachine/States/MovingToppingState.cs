public class MovingToppingState : State
{
    private const float DelayReportReadiness = 1f;

    public bool IsReady { get; private set; }

    private void Start() { }

    private void OnEnable()
    {
        Invoke(nameof(ReportReadiness), DelayReportReadiness);
    }

    private void ReportReadiness()
    {
        IsReady = true;
    }
}
