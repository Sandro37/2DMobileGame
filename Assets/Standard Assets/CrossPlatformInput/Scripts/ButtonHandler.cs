using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class ButtonHandler : MonoBehaviour
    {
        public string Name;

        [SerializeField] Color pressedColor =  default;
        [Range(0,1)]
        [SerializeField] float scalePercent = 0.8f;
        Color initialColor;
        Vector3 initialScale;
        Image image;

        private void Start()
        {
            image = GetComponent<Image>();
            initialColor = image.color;
            initialScale = image.rectTransform.localScale;
        }
        void OnEnable()
        {

        }

        public void SetDownState()
        {
            CrossPlatformInputManager.SetButtonDown(Name);
            image.color = pressedColor;
            image.rectTransform.localScale *= scalePercent;
        }


        public void SetUpState()
        {
            CrossPlatformInputManager.SetButtonUp(Name);
            image.color = initialColor;
            image.rectTransform.localScale = initialScale;
        }


        public void SetAxisPositiveState()
        {
            CrossPlatformInputManager.SetAxisPositive(Name);
        }


        public void SetAxisNeutralState()
        {
            CrossPlatformInputManager.SetAxisZero(Name);
        }


        public void SetAxisNegativeState()
        {
            CrossPlatformInputManager.SetAxisNegative(Name);
        }

        public void Update()
        {

        }
    }
}
