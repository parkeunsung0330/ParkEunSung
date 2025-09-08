using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Autodesk.Fbx;
using Unity.VisualScripting;


namespace TestFantasy2D
{
    public enum AnimalType
    {
        BrownBear,
        Monkey,
        Pinguin,
        PolarBear,
        WhiteTiger
    }

    //public struct AnimalPrefabPari
    //{
    //    public AnimalType animalType;
    //    public GameObject prefab;
    //}

    public class AnimalsSpawn : MonoBehaviour
    {
        [System.Serializable]
        private struct AnimalPrefabPair
        {
            public AnimalType animalType;
            public GameObject prefab;
        }

        //[SerializeField] GameObject[] _animalPrefaps;
        [SerializeField] AnimalPrefabPair[] _animalPrefaps;
        

        // 생성 영역 범위

        [SerializeField] Vector2 _spawnAreaMin = new Vector2(-2f,-2f);
        [SerializeField] Vector2 _spawnAreaMax = new Vector2(2f,2f);
        // 생성 간격
        [SerializeField] float _spawnInterval = 5f;
        [SerializeField] int _maxSpawnCount = 10;// 최대 생성 수

        int _currentSpawnCount = 0;//현재 생성된 수
        bool _canSpawn = true;// 스폰 가능 || 불가능

        Dictionary<AnimalType, GameObject> _animalPrefabMap;

        private void Awake()
        {
            _spawnAreaMin = (Vector2)transform.position + _spawnAreaMin;
            _spawnAreaMax = (Vector2)transform.position + _spawnAreaMax;
        }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _animalPrefabMap = new Dictionary<AnimalType, GameObject>();
            foreach(var pair in _animalPrefaps)
            {
                _animalPrefabMap.Add(pair.animalType, pair.prefab);
            }
            StartCoroutine(SpawnAnimals());
            //StartCoroutine("SpawnAnimals");

        }

        //프리팹확인
        
        // Update is called once per frame
        void Update()
        {
        
        }


        IEnumerator SpawnAnimals()
        {

            while(_canSpawn)
            {
                if(_currentSpawnCount >= _maxSpawnCount)
                {
                    yield return new WaitForSeconds(_spawnInterval);
                    continue;
                }
                
                AnimalPrefabPair app = _animalPrefaps[UnityEngine.Random.Range(0, _animalPrefaps.Length)];
                AnimalType randomType = app.animalType;

                if(!_animalPrefabMap.TryGetValue(randomType,out GameObject prefab))
                {
                    Debug.LogError($"Prefab not found for {randomType}");
                    yield return null;
                }

                Vector2 spawnPosition = new Vector2(
                Random.Range(_spawnAreaMin.x, _spawnAreaMax.x),
                Random.Range(_spawnAreaMin.y, _spawnAreaMax.y)
                );

                
                Instantiate(prefab, spawnPosition, Quaternion.identity, this.transform);
                _currentSpawnCount++;
                yield return new WaitForSeconds(_spawnInterval);
            }
            //foreach (GameObject go in _animalPrefaps)
            //{
            //    // 랜덤 위치 생성
            //    Vector2 spawnPosition = new Vector2(
            //    Random.Range(_spawnAreaMin.x, _spawnAreaMax.x),
            //    Random.Range(_spawnAreaMin.y, _spawnAreaMax.y)
            //    );


            //    yield return new WaitForSeconds(_spawnInterval);
            //    Instantiate(go, spawnPosition, Quaternion.identity, this.transform);
            //}

        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;//스폰 칸 만들기
            //Vector2 center = (_spawnAreaMin+_spawnAreaMax)/2;
            Vector2 center = transform.position;
            Vector3 size = new Vector3(
                _spawnAreaMax.x - _spawnAreaMin.x,
                _spawnAreaMax.y - _spawnAreaMin.y,
                0
            );
            Gizmos.DrawWireCube(center, size);

        }
    }
}
