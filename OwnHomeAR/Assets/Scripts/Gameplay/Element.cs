using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace OwnHomeAR.Gameplay
{
    public abstract class Element : MonoBehaviour
    {
        [SerializeField] float secondClickTime = 0.25f;

        public Sprite Sprite;

        bool isMenuShown = default;
        Coroutine WaitForSecondClick;
        Action<bool> ShowMenuAction;
        Transform parentScale;

        private void OnMouseDown()
        {
            if (WaitForSecondClick == null)
                WaitForSecondClick = StartCoroutine(WaitClick());
            else
                ShowMenu(!isMenuShown);
        }

        public virtual void ShowMenu(bool flag)
        {
            isMenuShown = flag;
            ShowMenuAction?.Invoke(isMenuShown);
        }

        IEnumerator WaitClick()
        {
            yield return new WaitForSeconds(secondClickTime);
            WaitForSecondClick = null;
        }

        public virtual void InitElement(UnityEngine.Object obj, Action<bool> showMenuAction, Transform parentScale)
        {
            ShowMenuAction = showMenuAction;
            this.parentScale = parentScale;
        }
    }
}
