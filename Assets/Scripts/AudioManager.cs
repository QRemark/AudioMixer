using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private VolumeManager _volumeManager;
    [SerializeField] private SoundPlayer _soundPlayer;
    [SerializeField] private MuteToggle _muteToggle;

    [SerializeField] private Slider _masterVolume;
    [SerializeField] private Slider _buttonsVolume;
    [SerializeField] private Slider _backgroundVolume;
    [SerializeField] private Button _muteVolume;

    [SerializeField] private Button _s1Button;
    [SerializeField] private Button _s2Button;
    [SerializeField] private Button _s3Button;

    [SerializeField] private AudioClip _s1Clip;
    [SerializeField] private AudioClip _s2Clip;
    [SerializeField] private AudioClip _s3Clip;

    TextMeshProUGUI _buttonText;

    private float _startVolume = 0.5f;

    private string _masterName = "MasterVolume";
    private string _buttonsName = "ButtonsVolume";
    private string _backgroundName = "BackgroundVolume";

    private void Start()
    {
        _masterVolume.value = _startVolume;  
        _buttonsVolume.value = _startVolume; 
        _backgroundVolume.value = _startVolume;

        _volumeManager.SetVolume(_masterName, _masterVolume);
        _volumeManager.SetVolume(_buttonsName, _buttonsVolume);
        _volumeManager.SetVolume(_backgroundName, _backgroundVolume);

        _masterVolume.onValueChanged.AddListener(value => _volumeManager.SetVolume(_masterName, _masterVolume));
        _buttonsVolume.onValueChanged.AddListener(value => _volumeManager.SetVolume(_buttonsName, _buttonsVolume));
        _backgroundVolume.onValueChanged.AddListener(value => _volumeManager.SetVolume(_backgroundName, _backgroundVolume));

        _muteVolume.onClick.AddListener(() =>
        {
            _buttonText = _muteVolume.GetComponentInChildren<TextMeshProUGUI>();
            _muteToggle.ToggleMute(_buttonText);
        });

        _s1Button.onClick.AddListener(() => _soundPlayer.PlaySound(_s1Clip));
        _s2Button.onClick.AddListener(() => _soundPlayer.PlaySound(_s2Clip));
        _s3Button.onClick.AddListener(() => _soundPlayer.PlaySound(_s3Clip));
    }
}
