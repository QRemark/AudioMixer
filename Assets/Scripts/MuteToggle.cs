using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MuteToggle : MonoBehaviour
{
    [SerializeField] private Button _muteButton;
    [SerializeField] private TextMeshProUGUI _buttonText;

    private bool _isMuted = false;

    private string _muteText = "Mute";
    private string _unmuteText = "Unmute";

    private void Start()
    {
        _muteButton.onClick.AddListener(ToggleMute);
    }

    private void ToggleMute()
    {
        _isMuted = !_isMuted;
        AudioListener.pause = _isMuted;

        _buttonText.text = _isMuted ? _unmuteText : _muteText;
    }
}
