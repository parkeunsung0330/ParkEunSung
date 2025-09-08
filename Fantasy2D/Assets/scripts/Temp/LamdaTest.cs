using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TestFantasy2D
{
    public class LamdaTest : MonoBehaviour
    {
        List<ItemData> _inven;

        private void Awake()
        {
            _inven = new List<ItemData>();
            InitInven();
        }

        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

            //Func<int, int, int> add = Add;
            //Debug.Log(add(10,20));
            //Action<int, int> printAdd = (a, b) => Debug.Log(a + b);
            //printAdd(10, 20);

            //Action<string> printMsg = (msg) => Debug.Log(msg);
            //printMsg("���ٽ��Դϴ�.");

            //Action<string> printMsg = (msg) =>
            //{
            //    Debug.Log("���� ����");
            //    Debug.Log(msg);
            //    Debug.Log("���� ��");
            //};
            //printMsg("���ٽ��Դϴ�.");

            //ItemData item = null;
            //string name = item?.ItemName ?? "�̸�����";
            //Debug.Log(name);

            //Action<int> printEvenOdd = (n) => Debug.Log(n%2==0 ? "¦���Դϴ�." : "Ȧ���Դϴ�.");
            //printEvenOdd(10);
            //printEvenOdd(5);


            //foreach(ItemData item in _inven)
            //{
            //    Debug.Log(item.ItemName);
            //}

            //var items =  _inven.FindAll(x=>x.ItemID >50);

            //items.ForEach(x => Debug.Log(x.ItemName));

            //ItemData target = _inven.Find((x) => x.ItemID == 50);
            //Debug.Log(target.ItemName);

            //_inven.ForEach(x=>Debug.Log(x.ItemName) );

            //var filterd = _inven.Where(x=> x.ItemID>=10);


            //foreach (var item in filterd)
            //{
            //    Debug.Log($"10 �̻� ������ : {item.ItemName}");
            //}

            //var names = _inven.Select(item => item.ItemName).Where((x)=>x.Equals("������100"));
            //foreach (var name in names)
            //{
            //    Debug.Log($"������ �̸� : {name}");
            //}
            //var ordered = _inven.OrderByDescending(Item => Item.ItemID);
            //foreach(var item in ordered)
            //{
            //    Debug.Log($"���ĵ� ������ : {item.ItemName}");
            //}

            //var groups = _inven.GroupBy(Item => Item.ItemID / 10);
            //foreach(var group in groups)
            //{
            //    Debug.Log($"Group: {group.Key * 10}��");
            //    foreach (var item in group)
            //    {
            //        Debug.Log($" - {item.ItemName}");
            //    }
            //}

            //bool hasPotion = _inven.Any(item => item.ItemName.Contains("����"));
            //Debug.Log(hasPotion ? "���� ����" : "���� ����");

            //bool hasPotion = _inven.All(item => item.ItemID > 0);
            //Debug.Log(hasPotion ? "��� ���" : "0 ���� ����");

            //var item50 = _inven.LastOrDefault(Item => Item.ItemID >= 50);
            //Debug.Log(item50!= null ? item50.ItemName : "50�� ������ ����");

            //int count = _inven.Count(item => item.ItemID >= 50);
            //Debug.Log($"50 �̻� ������ ���� : {count}");

            var query =
                from item in _inven
                where item.ItemID >= 20 && item.ItemID<=30
                orderby item.ItemName descending
                select item.ItemName;

            foreach (var item in query)
            {
                //Debug.Log($"20~30�� ������ : {item}");
            }
            
        }


        //void Add(int a, int b)
        //{
            
        //}

        void InitInven()
        {
            _inven.Clear();
            for(int i = 1;i <=100;i++)
            {
                ItemData item = new ItemData();
                item.ItemID = i;
                item.ItemName = $"������{i}";

                _inven.Add(item);
            }

            
        }
    }
}
