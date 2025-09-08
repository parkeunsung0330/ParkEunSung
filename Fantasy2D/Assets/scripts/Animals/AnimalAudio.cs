using UnityEngine;

namespace TestFantasy2D
{
    public class AnimalAudio : MonoBehaviour
    {
        [SerializeField] AudioClip _hitClip;
        [SerializeField] AudioClip _setpClip;
        AudioSource _audio;
        
       public AudioClip Hitclip { get { return _hitClip; } }


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _audio = GetComponent<AudioSource>();
        }

        public void OffFootStep()
        {
            _audio.Stop();
        }
    }
}
