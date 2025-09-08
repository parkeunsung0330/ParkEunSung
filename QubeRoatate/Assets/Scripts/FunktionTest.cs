using UnityEngine;

namespace Cube
{
    public class FunktionTest : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            
            int a = 10;
            float b = 3.0f;
            float ret = Abc(a,b);
            Debug.Log(ret);
              
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        //int Add(int a, int b)
        //{
        //    int ret = a + b;
        //    return ret;
        //}

        float Abc(int a, float b)
        {
            float ret = a / b;
            return ret;
        }
    }
}
