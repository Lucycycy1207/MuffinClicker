using TMPro;
using UnityEngine;
/// <summary>
/// updates the Header children UI elements
/// </summary>
public class Header : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _totalMuffinsText;//total muffins

    /// <summary>
    /// Updates the total muffin text.
    /// </summary>
    /// <param name="counter">The total muffins</param>
    public void UpdateTotalMuffins(int counter)
{
        _totalMuffinsText.text = 
            counter == 1 ? 
            "1 muffin" : 
            $"{counter} muffins";

        //if (counter == 1)
        //{
        //    _totalMuffinsText.text = $"{counter} muffin";//format
        //}   
        //else
        //{
        //    _totalMuffinsText.text = $"{counter} muffins";
        //}
    }
}
