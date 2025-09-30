using UnityEngine;
using UnityEngine.AI;

namespace Fantasy3D
{
    public class EnemyMove : MonoBehaviour
    {
        [SerializeField] float _attackRange = 1.0f;
        [SerializeField] float _radius = 20f;
        [SerializeField] LayerMask _layer;
        GameObject _target;
        NavMeshAgent _agent;
        Animator _anim;
        Collider[] _colliders;//오버램에 들어온 충돌체 배열
        float _maxSpeed = 2.0f;

        public bool IsDead { get; set;}
        

        private void Start()
        {
            IsDead = false;
            //_target = GameObject.Find("Player");
            _agent = GetComponent<NavMeshAgent>();
            _agent.stoppingDistance = _attackRange;
            _anim = GetComponentInChildren<Animator>();
        }
        
        private void Update()
        {

            if (_target != null)
            {
                _agent.SetDestination(_target.transform.position);
                _agent.speed = _maxSpeed;
                _anim.SetBool("Walking",true);

                if (_agent.remainingDistance <= _attackRange && _agent.remainingDistance >0)
                {
                    _anim.SetTrigger("Attack");
                }
                //Debug.Log(_agent.remainingDistance);
            }
            else
            {
                _agent.speed = 0;
                _anim.SetBool("Walking", false);

            }

            DeadCheck();
            
        }

        private void FixedUpdate()
        {
            _colliders = Physics.OverlapSphere(this.transform.position, _radius, _layer);

            if(_colliders.Length == 0 )
            {
                _target = null;
            }
            else
            {
                foreach (Collider collider in _colliders)
                {
                    _target = collider.gameObject;
                }
                
            }

        }

        void DeadCheck()
        {
            if (IsDead)
            {
                _anim.SetTrigger("Death");
                _agent.speed = 0;
            }

            if(_anim.GetCurrentAnimatorStateInfo(0).IsName("Death")
                &&_anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                Destroy(this.gameObject);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(this.transform.position, _radius);
        }

    }
}
