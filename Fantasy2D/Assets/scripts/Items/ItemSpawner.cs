using UnityEngine;

namespace TestFantasy2D
{
    public class ItemSpawner : Singleton<ItemSpawner>
    {
        [SerializeField] Item[] _items;
        [SerializeField] float _dropChance = 0.9f;

        public void SpawnItems(Vector3 position)
        {
            // 0에서 1 사이의 랜덤 값 생성
            float randomValue = Random.value;

            // randomValue가 dropChance보다 작으면 아이템 드롭
            if(randomValue < _dropChance)
            {
                var item = Instantiate(_items[Random.Range(0, _items.Length)],position,Quaternion.identity);
            }
        }
    }
}
