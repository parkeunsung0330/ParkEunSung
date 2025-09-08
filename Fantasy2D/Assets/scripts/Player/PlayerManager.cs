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
                //애니메이션 처리
                if (_playerMove.Move.magnitude > 0.1f)
                {   
                    //방향을 애니메이터에 전달
                    _playerAnim.DirectionAnim(_playerMove.LookDirection.x, _playerMove.LookDirection.y);
                }
                //달리기 애니메이션 처리
                _playerAnim.RunAnim(_playerMove.Move.magnitude);
            }
            //공격처리
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
