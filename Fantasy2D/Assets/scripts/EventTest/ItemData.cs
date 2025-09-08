using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace TestFantasy2D
{
    public delegate void ItemAddDelegate(ItemData itemData);

    [System.Serializable]
    public class ItemData 
    {
        public int _itemID;
        public string _itemName;
        public string _spritePath;

        [System.NonSerialized]
        public Sprite itemSprite;

        
        public int ItemID { get { return _itemID; } set { _itemID = value; } }
        public string ItemName { get { return _itemName; }set { _itemName = value; } }
    }


    [System.Serializable]
    public class ItemDataList
    {
        public List<ItemData> items = new List<ItemData>();
    }
}
