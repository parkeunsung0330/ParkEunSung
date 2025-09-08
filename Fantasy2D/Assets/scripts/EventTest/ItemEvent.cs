using UnityEngine;

namespace TestFantasy2D
{
    public class ItemEvent
    {
        public static event ItemAddDelegate OnItemPickedUp;

        public static void ItemPickedUp(ItemData item)
        {
            OnItemPickedUp?.Invoke(item);
        }
        
    }
}
