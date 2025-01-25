using TMPro;
using UnityEngine;

public class MuteToggle : MonoBehaviour
{
    private bool _isMuted = false;

    private string _unmuteName = "Unmute";
    private string _muteName = "Mute";

    public void ToggleMute(TextMeshProUGUI buttonText)
    {
        _isMuted = !_isMuted;
        AudioListener.pause = _isMuted;

        buttonText.text = _isMuted ? _unmuteName : _muteName;
    }
}
