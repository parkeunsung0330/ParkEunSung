using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

namespace TestFantasy2D
{
    public class Inventory : MonoBehaviour
    {
        List<ItemData> _items = new List<ItemData>();

        string _savePath;//���̺� ������ ��� �����Ұ��� ��θ� �����������

        public List<ItemData> Items { get { return _items; } }

        private void Awake()
        {
            _savePath = Path.Combine(Application.persistentDataPath, "Inventory.json");

            LoadFromJson();

            

            //ItemData data = new()
            //{
            //    ItemID = 3,
            //    ItemName = "Potion",
            //    _spritePath = "Sprites/Items/potion_blue"
            //};

            //_items.Add(data);

            
            //SaveToJson();

            //DeleteSaveFile();
        }

        public void SaveToJson()
        {
            serializableList<ItemData> wrapper = new serializableList<ItemData>();
            wrapper.DataList = _items;

            string json = JsonUtility.ToJson(wrapper, true);//����ȭ
            File.WriteAllText(_savePath, json);
            Debug.Log("�κ��丮 ���� �Ϸ� : " + _savePath);
        }

        public void LoadFromJson()
        {
            if(File.Exists(_savePath))
            {
                string json = File.ReadAllText(_savePath);
                serializableList<ItemData> wrapper = JsonUtility.FromJson<serializableList<ItemData>>(json);
                _items = wrapper.DataList ?? new List<ItemData>();
                Debug.Log("�κ��丮 �ҷ����� �Ϸ� : " + _items.Count + "�� ������");
            }
            else
            {
                Debug.LogWarning("���� ������ �����ϴ�.");
            }
        }

        public void AddInvenItem(ItemData item)
        {
            _items.Add(item);
            SaveToJson();
            Debug.Log($"{item.ItemName}��(��) �κ��丮�� �߰��Ǿ����ϴ�.");
        }


        public List<ItemData> GetAllItems()
        {
            return _items;
        }

        public void DeleteSaveFile()
        {
            if(File.Exists(_savePath))
            {
                File.Delete(_savePath);
                Debug.Log("�κ��丮 ���� ���� �Ϸ�");
            }
            else
            {
                Debug.LogWarning("������ ������ �����ϴ�.");
            }
        }
        private void OnEnable()
        {
            ItemEvent.OnItemPickedUp += AddItem;
        }

        private void OnDisable()
        {
            ItemEvent.OnItemPickedUp -= AddItem;
        }
        private void AddItem(ItemData item)
        {
            _items.Add(item);
            Debug.Log($"{item.ItemName}��(��) �κ��丮�� �߰��Ǿ����ϴ�.");
        }

        


    }
    [Serializable]
    public class serializableList<T>
    {
        public List<T> data;

        public List<T> DataList { get { return data; } set { data = value; } }
    }


}
