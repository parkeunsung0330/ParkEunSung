using System.Threading.Tasks;
using UnityEditor.PackageManager;
using UnityEngine;

namespace Fantasy3D
{
    public class NetworkTest : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        async void Start()
        {
            //var x = await NetworkManager.Instance.RequestByAsync<ResponseData>("/character/1", eMethod.Get);
            //if (x.errcode == "E0000")
            //{
            //    ReqCharacter[] cha = JsonHelper.GetJsonArray<ReqCharacter>(x.data);

            //    foreach(ReqCharacter c in cha)
            //    {
            //        Debug.Log(c.cname);
            //    }
            //}

            ReqCharacter reqch = new()
            {

                user_uno = 1,
                cname = "asd",
                ctribe = "asd",
                clv = 10,
                cgender = 1,
                cclass = "asd",
                str = 1,
                dex=1,
                wisd=1,
                hp=1,
                mana=1
            };

            string jsonString = JsonUtility.ToJson(reqch);

            var x = await NetworkManager.Instance.RequestByAsync<ResponseData>("/character",eMethod.Post,jsonString);

            if(x.errcode == "E0000")
            {
                Debug.Log(x.data);
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
