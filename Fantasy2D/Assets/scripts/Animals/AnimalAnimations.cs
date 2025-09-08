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
            _anim = GetComponent<Animator>();//�ʱⰪ �ֱ�
            _stat = GetComponent<StatsData>();
        }


        public void DirectionAnim(float x, float y)
        {
            _anim.SetFloat("LookX", x);//�ִϸ��̼� ������ X
            _anim.SetFloat("LookY", y);//�ִϸ��̼� ������ Y
        }

        public void Attack1()
        {
            _anim.SetTrigger("Attack1");
        }

        public IEnumerator EndAttackAfterAnimation()// Attack1�ִϸ��̼��� ���ư����� ��� Ȯ���ϴ� �Լ�
        {
            AnimatorStateInfo stateInfo = _anim.GetCurrentAnimatorStateInfo(0);//���� �ִϸ��̼� ���� ��������

            while (!stateInfo.IsName("Attack"))//���ݻ��°� �ƴϸ� ��� Ȯ���ؼ� ���ݻ��� Ȯ��
            {
                stateInfo = _anim.GetCurrentAnimatorStateInfo(0);//�ִϸ��̼� ���� ������Ʈ
                yield return null;//�������� ��ٸ���
            }

            float animationLength = stateInfo.length;//�ִϸ��̼��� ���ݻ����̸� �ִϸ��̼� ���� ����
            yield return new WaitForSeconds(animationLength);//�ִϸ��̼��� ���� ������ ��ٸ���
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
                AnimatorStateInfo stateInfo = _anim.GetCurrentAnimatorStateInfo(0);//���� �ִϸ��̼� ���� ��������

                while (!stateInfo.IsName("Death"))//�������°� �ƴϸ� ��� Ȯ���ؼ� �������� Ȯ��
                {
                    stateInfo = _anim.GetCurrentAnimatorStateInfo(0);//�ִϸ��̼� ���� ������Ʈ
                    yield return null;//�������� ��ٸ���
                }

                float animationLength = stateInfo.length;//�ִϸ��̼��� ���ݻ����̸� �ִϸ��̼� ���� ����
                yield return new WaitForSeconds(animationLength);//�ִϸ��̼��� ���� ������ ��ٸ���

                // ���� ������Ʈ ����
                Destroy(this.gameObject);

                ItemSpawner.Instance.SpawnItems(transform.position);
            }
        }
    }
}