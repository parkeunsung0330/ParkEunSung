using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TestFantasy2D
{
    
    public class ItemSlot : MonoBehaviour
    {
        Image _itemImg;
        TMP_Text _text;

        void Awake()
        {
            _itemImg = GetComponentInChildren<Image>();
            _text = GetComponentInChildren<TMP_Text>();
        }

        public void SetItem(ItemData item)
        {
            _text.text = item.ItemName;
            item.itemSprite = Resources.Load<Sprite>(item._spritePath);
            _itemImg.sprite = item.itemSprite;
        }
    }
}
