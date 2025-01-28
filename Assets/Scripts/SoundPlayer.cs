using UnityEngine;
using UnityEngine.UI;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource; 
    [SerializeField] private AudioClip[] _soundClips;
    [SerializeField] private Button[] _soundButtons;

    public void Initialize()
    {
        for (int i = 0; i < _soundButtons.Length; i++)
        {
            int index = i;
            _soundButtons[i].onClick.AddListener(()=>PlaySound(index));
        }
    }

    private void PlaySound(int clipIndex)
    {
        _audioSource.PlayOneShot(_soundClips[clipIndex]);
    }
}


