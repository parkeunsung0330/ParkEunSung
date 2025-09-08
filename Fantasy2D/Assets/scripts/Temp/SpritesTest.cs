using UnityEngine;

namespace TestFantasy2D
{
    public class Prefabs : MonoBehaviour
    {
        SpriteRenderer _sp;


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _sp = GetComponent<SpriteRenderer>();

            _sp.color = Color.red;
            //_sp.flipX = true;
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
