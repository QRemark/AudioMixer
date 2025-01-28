using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider[] _volumeSliders;

    private string[] _volumeNames;
    private float _startVolume;

    public void Initialize(string[] volumeParams, float startVolume)
    {
        _volumeNames = volumeParams;
        _startVolume = startVolume;

        for(int i = 0;  i < _volumeNames.Length; i++)
        {
            int index = i;
            _volumeSliders[i].value = _startVolume;
            SetVolume(_volumeNames[index], _startVolume);

            _volumeSliders[i].onValueChanged.AddListener(value => SetVolume(_volumeNames[index], value));
        }
    }

    private void SetVolume(string parameterName, float sliderValue)
    {
        float volume = Mathf.Log10(sliderValue) * 20;
        _audioMixer.SetFloat(parameterName, volume);
    }
}
