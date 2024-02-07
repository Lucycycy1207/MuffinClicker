using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField]
    private GameManager _gameManager;

    [Header("Muffin")]
    [SerializeField]
    private TextMeshProUGUI _muffinlevelText;

    [SerializeField]
    private TextMeshProUGUI _muffinCostText;

    [SerializeField]
    private float _muffinCostPowerScale = 1.5f;

    [Header("MilkShake")]
    [SerializeField]
    private TextMeshProUGUI _milkShakelevelText;

    [SerializeField]
    private TextMeshProUGUI _milkShakeCostText;

    [SerializeField]
    private float _milkshakeCostPowerScale = 2f;

    private int _muffinLevel = 0;
    private int _MilkShakeLevel = 0;

    private int CurrentMuffinCost
    {
        get
        {
            return 5 + Mathf.RoundToInt(Mathf.Pow(_muffinLevel, _muffinCostPowerScale));
        }
    }

    private int CurrentMilkShakeCost
    {
        get
        {
            return 20 + Mathf.RoundToInt(Mathf.Pow(_MilkShakeLevel, _milkshakeCostPowerScale));
        }
    }

    private void Start()
    {
        UpdateMuffinUI();
        UpdateMilkShakeUI();

    }


    

    public void TotalMuffinChanged(int totalMuffin)
    {
        bool canAfford = totalMuffin >= CurrentMuffinCost;
        _muffinCostText.color = canAfford ? Color.green : Color.red;
    }

    public void TotalMilkShakeChanged(int totalMilkShake)
    {
        bool canAfford = totalMilkShake >= CurrentMilkShakeCost;
        _milkShakeCostText.color = canAfford ? Color.green : Color.red;
    }
    public void OnMuffinUpgradeClicked()
    {
        int currentCost = CurrentMuffinCost;
        bool purchaseUpgrade =_gameManager.TryMuffinPurchaseUpgrade(currentCost, _muffinLevel);
        if (purchaseUpgrade)
        {
            _muffinLevel++;
            UpdateMuffinUI();

        }
    }

    public void OnMilkShakeUpgradeClicked()
    {
        int currentCost = CurrentMilkShakeCost;
        bool purchaseUpgrade = _gameManager.TryMilkShakePurchaseUpgrade(currentCost, _MilkShakeLevel);
        if (purchaseUpgrade)
        {
            _MilkShakeLevel++;
            UpdateMilkShakeUI();

        }
    }

    private void UpdateMuffinUI()
    {
        _muffinlevelText.text = _muffinLevel.ToString();
        _muffinCostText.text = CurrentMuffinCost.ToString();
        //Debug.Log("muffin UI: " + _muffinlevelText.text + _muffinCostText.text);
    }

    private void UpdateMilkShakeUI()
    {
        _milkShakelevelText.text = _MilkShakeLevel.ToString();
        _milkShakeCostText.text = CurrentMilkShakeCost.ToString();
        //Debug.Log("muffin UI: " + _milkShakelevelText.text + _milkShakeCostText.text);
    }
}
