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

        string _savePath;//세이브 파일은 어디에 저장할건지 경로를 설정해줘야함

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

            string json = JsonUtility.ToJson(wrapper, true);//직렬화
            File.WriteAllText(_savePath, json);
            Debug.Log("인벤토리 저장 완료 : " + _savePath);
        }

        public void LoadFromJson()
        {
            if(File.Exists(_savePath))
            {
                string json = File.ReadAllText(_savePath);
                serializableList<ItemData> wrapper = JsonUtility.FromJson<serializableList<ItemData>>(json);
                _items = wrapper.DataList ?? new List<ItemData>();
                Debug.Log("인벤토리 불러오기 완료 : " + _items.Count + "개 아이템");
            }
            else
            {
                Debug.LogWarning("저장 파일이 없습니다.");
            }
        }

        public void AddInvenItem(ItemData item)
        {
            _items.Add(item);
            SaveToJson();
            Debug.Log($"{item.ItemName}이(가) 인벤토리에 추가되었습니다.");
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
                Debug.Log("인벤토리 파일 삭제 완료");
            }
            else
            {
                Debug.LogWarning("삭제할 파일이 없습니다.");
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
            Debug.Log($"{item.ItemName}이(가) 인벤토리에 추가되었습니다.");
        }

        


    }
    [Serializable]
    public class serializableList<T>
    {
        public List<T> data;

        public List<T> DataList { get { return data; } set { data = value; } }
    }


}
