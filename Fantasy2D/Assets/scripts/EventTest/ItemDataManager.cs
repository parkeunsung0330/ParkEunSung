using NUnit.Framework;
using System.IO;
using UnityEngine;
using System.Collections.Generic;

namespace TestFantasy2D
{
    public class ItemDataManager
    {
        private ItemDataList _itemList = new ItemDataList();
        string _jsonPath;

        public ItemDataManager()
        {
            _jsonPath = Path.Combine(Application.dataPath, "Resources/Items.json");
            LoadItems();
        }

        public void LoadItems()
        {
            if (File.Exists(_jsonPath))
            { 
                string json = File.ReadAllText(_jsonPath);
                _itemList = JsonUtility.FromJson<ItemDataList>(json);//¿ªÁ÷·Ä

                //Sprite 
                foreach(var item in _itemList.items)
                {
                    item.itemSprite = Resources.Load<Sprite>(item._spritePath);
                }
            }
            else
            {
                _itemList = new ItemDataList();
            }
        }

        public ItemData GetItemByld(int id)
        {
            return _itemList.items.Find(item => item.ItemID == id);
        }

        public List<ItemData> GetAllItems()
        {
            return _itemList.items;
        }

    }
}
