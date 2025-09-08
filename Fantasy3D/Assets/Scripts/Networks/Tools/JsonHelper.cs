using System;
using UnityEngine;

namespace Fantasy3D
{
    public class JsonHelper
    {
        [Serializable]
        private class Wrapper<T>
        {
            public T[] array;
        }

        public static T[] GetJsonArray<T>(string json)
        {
            string newJson = "{\"array\": " + json + "}";
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);//역직렬화 : 문자열 -> 객체
            return wrapper.array;
        }

    }
}
