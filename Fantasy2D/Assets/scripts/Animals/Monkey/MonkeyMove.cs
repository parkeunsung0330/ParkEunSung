using UnityEngine;

namespace TestFantasy2D
{
    public class MonkeyMove : AnimalMove
    {
        //이동 속도
        float _moveSpeed = 2.0f;
        public override float MoveSpeed { get { return _moveSpeed; }set { _moveSpeed = value; } }
    }
}
