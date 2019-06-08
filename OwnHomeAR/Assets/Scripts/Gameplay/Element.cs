using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using OwnHomeAR.ObjectControllers;
using OwnHomeAR.UI;

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

        ScaleController scale;
        MoveController move;
        RotateController rotate;

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

            scale.InitController(parentScale, this);
            rotate.InitController(parentScale, this);
            move.InitController(parentScale, this);
        }

        IEnumerator WaitClick()
        {
            yield return new WaitForSeconds(secondClickTime);
            WaitForSecondClick = null;
        }

        public virtual void InitElement(UnityEngine.Object obj, Action<bool> showMenuAction, Transform parentScale, ControllesMenu.Controllers control)
        {
            ShowMenuAction = showMenuAction;
            this.parentScale = parentScale;
            scale = control.Scale;
            rotate = control.Rotate;
            move = control.Move;
        }
    }
}
