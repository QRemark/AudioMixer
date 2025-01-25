using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    public void SetVolume(string name, Slider slider)
    {
        float value = Mathf.Log10(slider.value) * 20;
        _audioMixer.SetFloat(name, value);
    }
}
