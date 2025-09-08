using UnityEditor.Build.Content;
using UnityEngine;

namespace TestFantasy2D
{
    public class LightingItem : Item
    {
        [SerializeField] AudioClip _clip;
        float _addAgi = 0.2f;

        

        public void AddAgility(GameObject go)
        {
            PlayerData player = go.GetComponent<PlayerData>();
            if(player != null)
            {
                player.ChangeAgility(_addAgi);
                PlayerAudio audio = player.GetComponent<PlayerAudio>();
                audio.SoundEffect(_clip);   

                Destroy(this.gameObject);
            }

            
        }
    }
}
