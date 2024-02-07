
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Raining desserts in background.
/// </summary>
public class DessertRain : MonoBehaviour
{
    [SerializeField]
    private RawImage _dessertFallPrefab;

    [SerializeField]
    private float _dessertIntervalLow = 0.4f;
    [SerializeField]
    private float _dessertIntervalHigh = 0.8f;

    private float _dessertInterval = 0;
    private float timer = 0;

    // Update is called once per frame
    void Update()
    {
        DessertRainSetUp();
    }

    /// <summary>
    /// 1. Set up dessert frequency.
    /// 2. make dessert rain using DessertFallPrefab.
    /// </summary>
    private void DessertRainSetUp()
    {
        timer += Time.deltaTime;

        if (timer > _dessertInterval)
        {
            timer = 0;
            _dessertInterval = Random.Range(_dessertIntervalLow, _dessertIntervalHigh);

            //// create a copy of _textRewardPrefab as a child of the myFirstScript transform
            RawImage dessertfallclone = Instantiate(_dessertFallPrefab, transform);
        }
    }
}
