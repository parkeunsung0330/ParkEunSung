using UnityEngine;

namespace TestFantasy2D
{
    public class Item : MonoBehaviour
    {
        [SerializeField] int _healthAmount = 10;
        public int HealthAmount { get { return _healthAmount; } }
    }
}
