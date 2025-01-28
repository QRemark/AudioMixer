using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioHandler : MonoBehaviour
{
    [SerializeField] private Volume _volume;
    [SerializeField] private SoundPlayer _soundPlayer;

    private float _startVolume = 0.5f;

    private string[] _volumeNames = { "MasterVolume", "ButtonsVolume", "BackgroundVolume" };

    private void Start()
    {
        _volume.Initialize(_volumeNames, _startVolume);
        _soundPlayer.Initialize();
    }
}
