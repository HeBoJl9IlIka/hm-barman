using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class PouringState : State
{
    [SerializeField] private SelectingCupState _selectingCupState;
    [SerializeField] private Shaker _shaker;
    [SerializeField] private Cap _cap;
    [SerializeField] private Cocktail _cocktail;
    [SerializeField] private float _durationCap;
    [SerializeField] private float _durationCup;
    [SerializeField] private float _durationShaker;
    [SerializeField] private float _durationRotationShaker;
    [SerializeField] private float _durationPourOutShaker;
    [SerializeField] private float _delayCup;
    [SerializeField] private float _delayShaker;
    [SerializeField] private float _delayFillCup;
    [SerializeField] private float _delayPourOutShaker;
    [SerializeField] private float _delayReportReadiness;
    [SerializeField] private Vector3 _targetRotationCap;
    [SerializeField] private Vector3 _targetRotationShaker;
    [SerializeField] private Vector3 _targetRotationCocktail;
    [SerializeField] private Transform _targetPositionCup;
    [SerializeField] private Transform _targetPositionCocktail;
    [SerializeField] private Transform[] _pathCap;
    [SerializeField] private Transform[] _pathShaker;
    
    private Cup _cup;
    private Drink _drinkCup;
    private Transform _startPositionDrink;
    private Transform _endPositionDrink;

    public event UnityAction Poured;

    public bool IsPoured { get; private set; }

    private void OnEnable()
    {
        _cup = _selectingCupState.Cup;
        _drinkCup = _selectingCupState.Drink;
        _startPositionDrink = _selectingCupState.StartPositionDrink;
        _endPositionDrink = _selectingCupState.EndPositionDrink;

        OpenShaker();
        Invoke(nameof(MoveShaker), _delayShaker);
        Invoke(nameof(RotateShaker), _delayShaker);
        Invoke(nameof(MoveCup), _delayCup);
        Invoke(nameof(FillCup), _delayFillCup);
        Invoke(nameof(PourOutShaker), _delayPourOutShaker);
        Invoke(nameof(ReportReadiness), _delayReportReadiness);
    }

    private void OpenShaker()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(_cap.transform.DOMove(_pathCap[0].position, _durationCap));
        sequence.Insert(0, _cap.transform.DORotate(_targetRotationCap, _durationCap));

        sequence.Append(_cap.transform.DOMove(_pathCap[1].position, _durationCap));
    }

    private void MoveShaker()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(_shaker.transform.DOMove(_pathShaker[0].position, _durationShaker));
        sequence.Append(_shaker.transform.DOMove(_pathShaker[1].position, _durationShaker));
        sequence.Append(_shaker.transform.DOMove(_pathShaker[2].position, _durationShaker));
        sequence.Append(_shaker.transform.DOMove(_pathShaker[3].position, _durationShaker));
    }

    private void RotateShaker()
    {
        _shaker.transform.DORotate(_targetRotationShaker, _durationRotationShaker);
    }

    private void MoveCup()
    {
        _cup.transform.DOMove(_targetPositionCup.position, _durationCup);
    }

    private void FillCup()
    {
        _drinkCup.transform.position = _startPositionDrink.position;
        _drinkCup.transform.DOMove(_endPositionDrink.position, _durationShaker);
    }

    private void PourOutShaker()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(_cocktail.transform.DOMove(_targetPositionCocktail.position, _durationPourOutShaker));
        sequence.Insert(0, _cocktail.transform.DORotate(_targetRotationCocktail, _durationPourOutShaker));
    }

    private void ReportReadiness()
    {
        Poured?.Invoke();
        IsPoured = true;
    }
}
