using UnityEngine;

namespace TestFantasy2D
{
    public class ItemSpawner : Singleton<ItemSpawner>
    {
        [SerializeField] Item[] _items;
        [SerializeField] float _dropChance = 0.9f;

        public void SpawnItems(Vector3 position)
        {
            // 0���� 1 ������ ���� �� ����
            float randomValue = Random.value;

            // randomValue�� dropChance���� ������ ������ ���
            if(randomValue < _dropChance)
            {
                var item = Instantiate(_items[Random.Range(0, _items.Length)],position,Quaternion.identity);
            }
        }
    }
}
