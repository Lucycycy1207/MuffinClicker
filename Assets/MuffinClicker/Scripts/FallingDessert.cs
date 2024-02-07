using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 1. Initialize the dessert location.
/// 2. Initialize the dessert type.
/// 3. make the dessert falls.
/// 4. Destroys the dessert;
/// </summary>
public class FallingDessert : MonoBehaviour
{

    [SerializeField]
    private RawImage _currentDessert;

    [SerializeField]
    private Texture2D[] _desserts;

    [SerializeField]
    private float _movespeed;

    [SerializeField]
    private float _initialY;

    [SerializeField]
    private float _initialXLow = -910;
    [SerializeField]
    private float _initialXHigh = 910;
    [SerializeField]
    private float _terminalY = -540;


    // Start is called before the first frame update
    void Start()
    {
        InitialRandomDessert();
    }

    /// <summary>
    /// 1. Initial the dessert position.
    /// 2. initial the type of dessert.
    /// </summary>
    private void InitialRandomDessert()
    {
        int dessertNum = _desserts.Length;
        int dessertIndex = Random.Range(0, dessertNum);

        Vector3 randomPos = 
            MyToolbox.GetRandomVector2
            (_initialXLow, _initialXHigh, _initialY, _initialY);//x(-910, 910)

        _currentDessert.transform.localPosition = randomPos;
        _currentDessert.texture = _desserts[dessertIndex];
    }

    // Update is called once per frame
    void Update()
    {
        MakeDessertFall();
    }

    /// <summary>
    /// 1. make the dessert fall with const speed.
    /// 2. destroy it when it is out of screen.
    /// </summary>
    private void MakeDessertFall()
    {
        transform.Translate(0, _movespeed * Time.deltaTime, 0);

        if (transform.localPosition.y < _terminalY)  
            Destroy(gameObject);
    }

}
