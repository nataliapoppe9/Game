using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class VolumeSetting : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;

    public void ChangeVolumeMusic(float _volume)
    {
        mixer.SetFloat("MusicVolume", _volume);
    }


}
