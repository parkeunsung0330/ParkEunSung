using UnityEngine;
using System.Collections;

namespace TestFantasy2D
{
    public class AnimalAttack : MonoBehaviour,IAttack
    {
        bool _isAttacking = false;
        AnimalAnimations _animalAnim;
        AnimalMove _animalMove;
        Weapon _putAttack;

        public bool IsAttacking { get { return _isAttacking; } set { _isAttacking = value; } }


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _animalAnim = GetComponent<AnimalAnimations>();
            _animalMove = GetComponent<AnimalMove>();
            _putAttack = GetComponentInChildren<Weapon>();
        }

        public void StartAttack()
        {
            if (_isAttacking) return;

            _isAttacking = true;
            _animalMove.IsMoving = false;

            //애니메이션 처리
            Vector2 roundedDirection = _animalMove.RoundDirection(_animalMove.LookDirection); 
            _animalAnim.DirectionAnim(roundedDirection.x, roundedDirection.y);
            _animalAnim.Attack1();
            _animalAnim.IsEndAttackAnima = false;

            // 발 위치 업데이트
            _putAttack.SetColliderOffset(roundedDirection);

            _putAttack.TurnOnCollider();

            StartCoroutine(EndAttack());

        }

        public IEnumerator EndAttack()
        {
            //함수가 끝날때 까지 대기
            yield return StartCoroutine(_animalAnim.EndAttackAfterAnimation());

            _putAttack.TurnOffCollider();
            _isAttacking = false;
            _animalMove.IsMoving = true;
        }
    }
}
