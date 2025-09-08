using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SubsystemsImplementation;


namespace TestFantasy2D
{
    public class ItemGridUI : MonoBehaviour
    {
        [SerializeField] GameObject _itemSlot;
        [SerializeField] Inventory _inven;

        Transform _contentParent;
        //ItemDataManager _itemDataManager;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start()
        {
            //_itemDataManager = new ItemDataManager();
            _contentParent = GetComponent<Transform>();

            List<ItemData> items = _inven.GetAllItems();
            ShowItems(items);
        }

        void ShowItems(List<ItemData> items)
        {
            foreach(Transform child in _contentParent)
            {
                Destroy(child.gameObject);
            }

            foreach(ItemData itme in items)
            {
                GameObject slotObj = Instantiate(_itemSlot, _contentParent);
                ItemSlot slot = slotObj.GetComponent<ItemSlot>();
                slot.SetItem(itme);
            }
        }
    }
}
