using System;
using System.Collections;
using UnityEngine;

namespace CodeBase.UILogic
{
    public class LoadingCurtain : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            canvasGroup.alpha = 1;
        }

        public void Hide() => 
            StartCoroutine(HideCorun());

        private IEnumerator HideCorun()
        {
            while(canvasGroup.alpha > Constants.Epsilon)
            {
                canvasGroup.alpha -= Time.deltaTime;
                yield return null;
            }

            gameObject.SetActive(false);

        }
    }
}
