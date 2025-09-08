using UnityEngine;

namespace TestFantasy2D
{
    public class PlayerManager : MonoBehaviour
    {
        PlayerData _playerData;
        PlayerAnimation _playerAnim;
        PlayerMove _playerMove;
        PlayerAttack _playerAttack;

       
        private void Awake()
        {

            _playerAnim = GetComponent<PlayerAnimation>();
            _playerMove = GetComponent<PlayerMove>(); 
            _playerAttack = GetComponent<PlayerAttack>();
            _playerData = GetComponent<PlayerData>();
        
        }

        
        void Update()
        {
            if(_playerMove.IsMoving)
            {

                _playerMove.GetDirection();
                //�ִϸ��̼� ó��
                if (_playerMove.Move.magnitude > 0.1f)
                {   
                    //������ �ִϸ����Ϳ� ����
                    _playerAnim.DirectionAnim(_playerMove.LookDirection.x, _playerMove.LookDirection.y);
                }
                //�޸��� �ִϸ��̼� ó��
                _playerAnim.RunAnim(_playerMove.Move.magnitude);
            }
            //����ó��
            if(!_playerAttack.IsAttacking&&Input.GetButtonDown("Fire1"))
            {
                _playerAttack.StartAttack();
            }

            
        }

        void FixedUpdate()
        {
            if(_playerMove.IsMoving)
            {
                _playerMove.MoveCharacter();
            }
        }
    }
}
