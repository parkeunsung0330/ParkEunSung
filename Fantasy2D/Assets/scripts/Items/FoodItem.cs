using Unity.VisualScripting;
using UnityEngine;

namespace TestFantasy2D
{
    public class FoodItem : Item
    {
        ItemData _data = new ItemData();

        private void Start()
        {
            _data.ItemID = 1;
            _data.ItemName = "Meat";
            _data._spritePath = "Sprites/Items/food_meat";
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {

            PlayerData playerData = collision.gameObject.GetComponent<PlayerData>();

            if(playerData != null)
            {

                if (playerData.CurrentHealth < playerData.MaxHealth)
                {
                    playerData.ChangeHealth(HealthAmount);
                    ItemEvent.ItemPickedUp(_data);
                    Destroy(gameObject);
                }
            }
        }
    }
}
