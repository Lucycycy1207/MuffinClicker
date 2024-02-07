using TMPro;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// 1. Handle the button click.
/// 2. Keep track of our total muffins.
/// 3. Crit logic.
/// 4. Create total muffins.
/// </summary>
public class GameManager : MonoBehaviour
{
    public UnityEvent<int> OnTotalMuffinsChanged;

    // [SerializeField] make the value changable in Unity
    //or do public int _counter = 0; but not recommend
    private int _totalMuffins = 0;

    private int _muffinsPerClick = 1;

    private int _muffinsPerSecond = 0;

    [Range(0f, 1f)]
    [SerializeField]
    private float _critChance = 0.01f;

    [SerializeField]
    private TextMeshProUGUI _muffinPerSecText;

    private int TotalMuffins
    {
        get
        {
            return _totalMuffins;
        }
        set
        {
            _totalMuffins = value;
            OnTotalMuffinsChanged.Invoke(_totalMuffins);
        }
    }

    private int TotalMuffinsPerSecond
    {
        get
        {
            return _muffinsPerSecond;
        }
        set
        {
            _muffinsPerSecond = value;
        }
    }
    public void UpdateMuffinPerSec()
    {
        //Debug.Log("update " + TotalMuffinsPerSecond);
        TotalMuffins += TotalMuffinsPerSecond;
    }

    /// <summary>
    /// Add muffins to the total muffins.
    /// </summary>
    /// <returns>Returns the total muffins.</returns>
    public int AddMuffins()
    {
        int addedMuffins;

        //1% possibility, *10x  _muffinsPerClick
        if (Random.value <= _critChance)
        {
            addedMuffins = _muffinsPerClick * 10;
        }
        else//normal
        {
            addedMuffins = _muffinsPerClick;
        }

        TotalMuffins += addedMuffins;
        
        return addedMuffins;
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        //_camera.enabled = false;
        TotalMuffins = 0;
        InvokeRepeating("UpdateMuffinPerSec", 0f, 1f);


    }

    public bool TryMuffinPurchaseUpgrade(int currentCost, int level)
    {
        if (TotalMuffins >= currentCost)
        {
            //purchase
            TotalMuffins -= currentCost;
            level++;
            _muffinsPerClick = 1 + level * 2;
            return true;
        }
        return false;
    }

    public bool TryMilkShakePurchaseUpgrade(int currentCost, int level)
    {
        if (TotalMuffins >= currentCost)
        {
            //purchase
            TotalMuffins -= currentCost;
            level++;
            TotalMuffinsPerSecond += level;
            //Debug.Log("per second+" + TotalMuffinsPerSecond);
            _muffinPerSecText.text = TotalMuffinsPerSecond + " Muffins / Second";
            return true;
        }
        return false;
    }

}
