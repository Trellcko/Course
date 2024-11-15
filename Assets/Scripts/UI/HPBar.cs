using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.GameLogic.UILogic
{
    public class HPBar : MonoBehaviour
    {
        [SerializeField] private Image _image;

        public void SetValue(float max, float value)
            => _image.fillAmount = Mathf.Clamp01(value / max);
    }
}
