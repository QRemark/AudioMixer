using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

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
    [SerializeField] private AudioSource _backgroundSource;
    [SerializeField] private AudioSource _buttonSource;

    private bool _isMuted = false;

    private float _startVolume = 0.5f;

    private string _masterName = "MasterVolume";
    private string _buttonsName = "ButtonsVolume";
    private string _backgroundName = "BackgroundVolume";

    private void Start()
    {
        _masterVolume.value = _startVolume;  
        _buttonsVolume.value = _startVolume; 
        _backgroundVolume.value = _startVolume;

        SetVolume(_masterName, _masterVolume.value);
        SetVolume(_buttonsName, _buttonsVolume.value);
        SetVolume(_backgroundName, _backgroundVolume.value);

        _masterVolume.onValueChanged.AddListener(value => SetVolume(_masterName, value));
        _buttonsVolume.onValueChanged.AddListener(value => SetVolume(_buttonsName, value));
        _backgroundVolume.onValueChanged.AddListener(value => SetVolume(_backgroundName, value));
        _muteVolume.onClick.AddListener(ToggleMute);

        _s1Button.onClick.AddListener(() => PlaySound(_s1Clip));
        _s2Button.onClick.AddListener(() => PlaySound(_s2Clip));
        _s3Button.onClick.AddListener(() => PlaySound(_s3Clip));
    }

    private void SetVolume(string name, float value)
    {
        _audioMixer.SetFloat(name, Mathf.Log10(value) * 20);
    }

    private void ToggleMute()
    {
        _isMuted = !_isMuted;
        AudioListener.pause = _isMuted;
        _muteVolume.GetComponentInChildren<TextMeshProUGUI>().text = _isMuted ? "Unmute" : "Mute";
    }

    private void PlaySound(AudioClip clip)
    {
        _buttonSource.PlayOneShot(clip);
    }
}
