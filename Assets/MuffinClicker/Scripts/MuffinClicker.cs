using UnityEngine;
using TMPro;//namespace for TextMeshProUGUI

public class MuffinClicker : MonoBehaviour
{
    [SerializeField]
    private GameManager _gameManager;
    
    [SerializeField]
    private TextMeshProUGUI _textRewardPrefab;
    
    [SerializeField]
    private float xl,xu,yl,yu;//random vector x and y

    /// <summary>
    /// Count how many times clicking the muffin.
    /// </summary>
    public void OnMuffinClicked()
    {
        int addedMuffins = _gameManager.AddMuffins();
        CreateTextRewardPrefab(addedMuffins);

    }

    private void CreateTextRewardPrefab(int addedMuffins)
    {
        // create a copy of _textRewardPrefab as a child of the myFirstScript transform
        TextMeshProUGUI textRewardClone = Instantiate(_textRewardPrefab, transform);

        // get Random Position and apply
        Vector2 randomVector = MyToolbox.GetRandomVector2(xl, xu, yl, yu);
        textRewardClone.transform.localPosition = randomVector;

        // Set the text.
        textRewardClone.text = $"+{addedMuffins}";


        // Get the TMP Component
        //TextMeshProUGUI textRewardText = textRewardClone.GetComponent<TextMeshProUGUI>();
        //try to avoid GetComponent
    }
}
