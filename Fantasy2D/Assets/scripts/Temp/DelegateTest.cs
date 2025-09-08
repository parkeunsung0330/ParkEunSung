using UnityEngine;

namespace TestFantasy2D
{

    public delegate void PrintDelegate(string aug);
    
    public class DelegateTest : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            PrintDelegate pd = PrintMsg1;
            pd += PrintMsg2;

            pd("HI");

            //PrintMsg1("¾È³ç");
            //PrintMsg2("¾È³ç");
        }

       

        void PrintMsg1(string aug)
        {
            Debug.Log("Print1 : " + aug);
        }

        void PrintMsg2(string aug)
        {
            Debug.Log("Print2 : " + aug);
        }



    }
}
