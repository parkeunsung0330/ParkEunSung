using UnityEngine;
using System.Collections;

namespace TestFantasy2D
{
    public class PlayerAnimation : MonoBehaviour
    {

        Animator _anim;


        public bool IsEndAttackAnima { get; set; } = false;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _anim = GetComponent<Animator>();//초기값 넣기
        }

        
        public void DirectionAnim(float x, float y)
        {
            _anim.SetFloat("LookX", x);//애니메이션 움직임 X
            _anim.SetFloat("LookY", y);//애니메이션 움직임 Y
        }

        public void RunAnim(float speed)
        {
            _anim.SetFloat("Speed", speed);
        }

        public void Attack1()
        {
            _anim.SetTrigger("Attack1");
        }

        public void AttackSpeedAnim(float speed)
        {
            _anim.SetFloat("AttackSpeed",speed);
        }

        public IEnumerator EndAttackAfterAnimation()
        {
            AnimatorStateInfo stateInfo = _anim.GetCurrentAnimatorStateInfo(0);

            while(!stateInfo.IsName("Attack1"))
            {
                stateInfo = _anim.GetCurrentAnimatorStateInfo(0);
                yield return null;
            }

            float animationLength = stateInfo.length;
            yield return new WaitForSeconds(animationLength);
        }
    }
}
