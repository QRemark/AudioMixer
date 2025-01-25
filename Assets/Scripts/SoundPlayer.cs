using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _buttonSource;

    public void PlaySound(AudioClip clip)
    {
        _buttonSource.PlayOneShot(clip);
    }
}
