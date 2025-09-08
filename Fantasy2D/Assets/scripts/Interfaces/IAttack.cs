using UnityEngine;
using System.Collections;

namespace TestFantasy2D
{
    public interface IAttack
    {
        public void StartAttack();
        public IEnumerator EndAttack();

    }
}
