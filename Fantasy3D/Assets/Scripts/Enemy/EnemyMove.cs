using UnityEngine;
using UnityEngine.AI;

namespace Fantasy3D
{
    public class EnemyMove : MonoBehaviour
    {
        [SerializeField] float _attackRange = 1.0f;
        GameObject _target;
        NavMeshAgent _agent;
        Animator _anim;
        

        private void Start()
        {
            _target = GameObject.Find("Player");
            _agent = GetComponent<NavMeshAgent>();
            _agent.stoppingDistance = _attackRange;
            _anim = GetComponentInChildren<Animator>();
        }
        
        private void Update()
        {

            if (_target != null)
            {
                _agent.SetDestination(_target.transform.position);
                if (_agent.remainingDistance <= _agent.stoppingDistance)
                {
                    _anim.SetTrigger("Attack");
                }
                //Debug.Log(_agent.remainingDistance);
            }
            
        }

        private void FixedUpdate()
        {

        }
    }
}
