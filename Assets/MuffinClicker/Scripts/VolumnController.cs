using UnityEngine;
using UnityEngine.UI;

public class VolumnController : MonoBehaviour
{
    [SerializeField]
    private Slider _volumeSlider;

    private void Start()
    {
        _volumeSlider.value = 1;
    }
    public void OnVolumeChanged()
    {
        Debug.Log("Volume changed");
        AudioListener.volume = _volumeSlider.value;
    }
}
