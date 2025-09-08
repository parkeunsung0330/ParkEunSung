using UnityEngine;

namespace TestFantasy2D
{
    public class PlayerInteractive : MonoBehaviour
    {

        PlayerMove _playerMove;
        bool _showGizmo = false;

        private void Start()
        {
            _playerMove = GetComponent<PlayerMove>();
        }

        private void Update()
        {

            if(Input.GetKeyDown(KeyCode.F)) 
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, _playerMove.LookDirection, 1.5f,LayerMask.GetMask("Item"));
                _showGizmo = true;
                
                if (hit.collider != null)
                {
                    //Debug.Log(hit.collider.gameObject.name);
                    LightingItem item = hit.collider.GetComponent<LightingItem>();
                    if(item != null)
                    {
                        item.AddAgility(gameObject);
                    }
                }
                
            }
            if (Input.GetKeyUp(KeyCode.F))
            {
                _showGizmo = false;
            }

        }

        

        private void OnDrawGizmos()
        {
            if(_showGizmo)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(transform.position, transform.position + (Vector3)_playerMove.LookDirection * 1.5f);
            }
        }
    }
}
