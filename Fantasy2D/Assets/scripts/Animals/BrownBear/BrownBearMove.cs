using UnityEngine;

namespace TestFantasy2D
{
    public class BrownBearMove : AnimalMove
    {
        //이동 속도
       [SerializeField] float _moveSpeed = 1.0f;
        public override float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }
    }
}
