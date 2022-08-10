using UnityEngine;
using System.Linq;

public class LevelStars : MonoBehaviour
{
    [SerializeField] private CheckingFillingShaker _checkingFillingShaker;
    [SerializeField] private CollectionStarsState _collectionStarsState;
    [SerializeField] private AnimatorSmallStar[] _smallStars;
    [SerializeField] private AnimatorBigStar[] _bigStars;

    public int StarsCount { get; private set; }

    private void OnEnable()
    {
        _checkingFillingShaker.Completed += OnCompleted;
        _collectionStarsState.Showed += OnShowed;
    }

    private void OnDisable()
    {
        _checkingFillingShaker.Completed -= OnCompleted;
        _collectionStarsState.Showed -= OnShowed;
    }

    private void OnCompleted()
    {
        if(StarsCount < 3)
            Activate();
    }

    private void OnShowed()
    {
        foreach (AnimatorSmallStar star in _smallStars)
        {
            if (star.IsActive)
            {
                _bigStars.FirstOrDefault(bigStar => bigStar.IsActive == false).Activate();
            }
        }
    }

    public void Activate()
    {
        _smallStars.FirstOrDefault(smallStar => smallStar.IsActive == false).Activate();
        ++StarsCount;
    }
}
