using UnityEngine;

namespace TestFantasy2D
{
    public class PlayerAudio : MonoBehaviour
    {

        AudioSource _audio;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _audio = GetComponent<AudioSource>();
        }

        public void SoundEffect(AudioClip clip)
        {
            _audio.PlayOneShot(clip);
        }

        
    }
}
