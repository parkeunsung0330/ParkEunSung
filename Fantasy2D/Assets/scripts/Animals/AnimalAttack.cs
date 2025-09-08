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

            //�ִϸ��̼� ó��
            Vector2 roundedDirection = _animalMove.RoundDirection(_animalMove.LookDirection); 
            _animalAnim.DirectionAnim(roundedDirection.x, roundedDirection.y);
            _animalAnim.Attack1();
            _animalAnim.IsEndAttackAnima = false;

            // �� ��ġ ������Ʈ
            _putAttack.SetColliderOffset(roundedDirection);

            _putAttack.TurnOnCollider();

            StartCoroutine(EndAttack());

        }

        public IEnumerator EndAttack()
        {
            //�Լ��� ������ ���� ���
            yield return StartCoroutine(_animalAnim.EndAttackAfterAnimation());

            _putAttack.TurnOffCollider();
            _isAttacking = false;
            _animalMove.IsMoving = true;
        }
    }
}
