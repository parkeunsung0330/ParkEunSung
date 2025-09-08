using Autodesk.Fbx;
using UnityEngine;
using System.Collections;

namespace TestFantasy2D
{
    public class PlayerAttack : MonoBehaviour, IAttack
    {

        bool _isAttacking = false;
        PlayerAnimation _playerAnim;
        PlayerMove _playerMove;
        Weapon _sword;

        public bool IsAttacking {  get { return _isAttacking; } set { _isAttacking = value; } }


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _playerAnim = GetComponent<PlayerAnimation>();
            _playerMove = GetComponent<PlayerMove>();
            _sword = GetComponentInChildren<Weapon>();
        }

        public void StartAttack()
        {
            if (_isAttacking) return;

            _isAttacking = true;
            _playerMove.IsMoving = false;

            //애니메이션 처리
            Vector2 roundedDirection = _playerMove.RoundDirection(_playerMove.LookDirection);
            _playerAnim.DirectionAnim(roundedDirection.x,roundedDirection.y);
            _playerAnim.Attack1();
            _playerAnim.IsEndAttackAnima = false;

            // 칼 위치 업데이트
            _sword.SetColliderOffset(roundedDirection);

            _sword.TurnOnCollider();

            StartCoroutine(EndAttack());

        }

        public IEnumerator EndAttack()
        {
            //함수가 끝날때 까지 대기
            yield return StartCoroutine(_playerAnim.EndAttackAfterAnimation());

            _sword.TurnOffCollider();
            _isAttacking = false;
            _playerMove.IsMoving = true;
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
