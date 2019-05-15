using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace OwnHomeAR.Gameplay
{
    public abstract class Element : MonoBehaviour
    {
        [SerializeField] float secondClickTime = 0.25f;
        [SerializeField] GameObject showMenu;

        public Sprite Sprite;

        bool isMenuShown = default;
        Coroutine WaitForSecondClick;

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
            showMenu.SetActive(isMenuShown);
        }

        IEnumerator WaitClick()
        {
            yield return new WaitForSeconds(secondClickTime);
            WaitForSecondClick = null;
        }

        public abstract void InitElement(Object obj);
    }
}
