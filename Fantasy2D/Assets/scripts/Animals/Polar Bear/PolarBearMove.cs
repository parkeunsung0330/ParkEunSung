using UnityEngine;

namespace TestFantasy2D
{
    public class PolarBearMove : AnimalMove
    {
        //이동 속도
        [SerializeField] float _moveSpeed = 0.5f;
        public override float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }
    }
}
