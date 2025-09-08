using UnityEngine;
using UnityEngine.UI;

namespace TestFantasy2D
{
    public class AnimalHealthBar : MonoBehaviour
    {

        [SerializeField] Image _healthBar;
        float _originalSize;
        

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _originalSize = _healthBar.rectTransform.rect.width;
        }

        public void SetValue(float value)
        {
            _healthBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _originalSize * value);
        }
    }
}