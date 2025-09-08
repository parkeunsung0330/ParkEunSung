using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

namespace TestFantasy2D
{
    public class AnimalManager : MonoBehaviour
    {
        
        AnimalAnimations _anim;
        //다형의 예제
        //BrownBearMove _brownBearMove;
        AnimalMove _animalMove;
        AnimalAttack _animalAttack;
        StatsData _statsData;
        GameObject _player;
        [SerializeField] float _attackDistance = 1.0f;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _anim = GetComponent<AnimalAnimations>();
            //_brownBearMove = GetComponent<BrownBearMove>();
            _animalMove = GetComponent<AnimalMove>();
            _player = GameObject.Find("Player");
            _animalAttack = GetComponent<AnimalAttack>();
            _statsData = GetComponent<StatsData>();
        }

        // Update is called once per frame
        void Update()
        {
            //거리를 계산해서 1f보다 작으면 공격
            if (Vector2.Distance(transform.position, _player.transform.position) < _attackDistance)
            {
                _animalMove.LookDirection =  _player.transform.position - transform.position;
                _animalAttack.StartAttack();
            }
            else
            {
                _anim.DirectionAnim(_animalMove.LookDirection.x, _animalMove.LookDirection.y);
            }

            if(_statsData.DeathCheck())
            {
                _animalMove.IsMoving = false;
                _anim.DeathAnim();
            }
        }

        private void FixedUpdate()
        {
            //Debug.Log("Distance : " + Vector2.Distance(transform.position, _player.transform.position));

            if(_animalMove.IsMoving)
            {
                _animalMove.MoveCharacter();
            }
        }
    }
}
