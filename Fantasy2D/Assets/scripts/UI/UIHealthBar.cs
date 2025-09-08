using UnityEngine;
using UnityEngine.UI;

namespace TestFantasy2D
{
    public class UIHealthBar : Singleton<UIHealthBar>
    {

        [SerializeField] Image _mask;
        float _originalSize;

        //public static UIHealthBar Instance {  get; private set; }


        //private void Awake()
        //{
        //   Instance = this;
        //}
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _originalSize = _mask.rectTransform.rect.width;
        }

        public void SetValue(float value)
        {
            _mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _originalSize * value);
        }
    }
}
