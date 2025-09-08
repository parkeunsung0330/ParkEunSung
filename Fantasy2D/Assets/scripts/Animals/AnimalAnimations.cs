using UnityEngine;
using System.Collections;
using System.Security.Cryptography;

namespace TestFantasy2D
{
    public class AnimalAnimations : MonoBehaviour
    {
        
        Animator _anim;
        StatsData _stat;
        

        public bool IsEndAttackAnima { get; set; } = false;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _anim = GetComponent<Animator>();//초기값 넣기
            _stat = GetComponent<StatsData>();
        }


        public void DirectionAnim(float x, float y)
        {
            _anim.SetFloat("LookX", x);//애니메이션 움직임 X
            _anim.SetFloat("LookY", y);//애니메이션 움직임 Y
        }

        public void Attack1()
        {
            _anim.SetTrigger("Attack1");
        }

        public IEnumerator EndAttackAfterAnimation()// Attack1애니메이션이 돌아가는지 계속 확인하는 함수
        {
            AnimatorStateInfo stateInfo = _anim.GetCurrentAnimatorStateInfo(0);//현재 애니메이션 상태 가져오기

            while (!stateInfo.IsName("Attack"))//공격상태가 아니면 계속 확인해서 공격상태 확인
            {
                stateInfo = _anim.GetCurrentAnimatorStateInfo(0);//애니메이션 상태 업데이트
                yield return null;//한프레임 기다리기
            }

            float animationLength = stateInfo.length;//애니메이션이 공격상태이면 애니메이션 길이 저장
            yield return new WaitForSeconds(animationLength);//애니메이션이 끝날 때까지 기다리기
        }

        public void DeathAnim()
        {
            if (!_stat.IsDead)
            {
                _anim.SetTrigger("Death");
                _stat.IsDead = true;
                StartCoroutine(EndDeathAfterAnim());
            }
            
            //if(_anim.GetCurrentAnimatorStateInfo(0).IsName("Death")&&_anim.GetCurrentAnimatorStateInfo(0).normalizedTime>=1.0f)
            //{
            //    Destroy(this.gameObject);
            //}

            IEnumerator EndDeathAfterAnim()
            {
                AnimatorStateInfo stateInfo = _anim.GetCurrentAnimatorStateInfo(0);//현재 애니메이션 상태 가져오기

                while (!stateInfo.IsName("Death"))//죽음상태가 아니면 계속 확인해서 죽음상태 확인
                {
                    stateInfo = _anim.GetCurrentAnimatorStateInfo(0);//애니메이션 상태 업데이트
                    yield return null;//한프레임 기다리기
                }

                float animationLength = stateInfo.length;//애니메이션이 공격상태이면 애니메이션 길이 저장
                yield return new WaitForSeconds(animationLength);//애니메이션이 끝날 때까지 기다리기

                // 게임 오브젝트 삭제
                Destroy(this.gameObject);

                ItemSpawner.Instance.SpawnItems(transform.position);
            }
        }
    }
}