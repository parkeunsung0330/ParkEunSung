using UnityEngine;

namespace TestFantasy2D
{
    public class ItemDataTest : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        

        void Start()
        {
            ItemDataManager manager = new ItemDataManager();

            ItemData data = manager.GetItemByld(2);

            Debug.Log(data._itemName);
        }

        
    }
}
