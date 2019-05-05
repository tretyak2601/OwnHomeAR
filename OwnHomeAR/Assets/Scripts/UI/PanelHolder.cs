using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

namespace OwnHomeAR.UI
{
    public abstract class PanelHolder : ToggleHolder
    {
        [SerializeField] MoveDirection direct;
        [SerializeField] SidePanel panel;

        public static event Action OnToggleClicekd;

        protected SidePanel Panel { get { return panel; } }

        private void Awake()
        {
            base.Awake();

            if (Toggle)
                Toggle.onValueChanged.AddListener(Move);
        }

        protected void Move(bool isOn)
        {
            panel.Group.allowSwitchOff = !isOn;
            OnToggleClicekd?.Invoke();

            if (!isOn) 
                foreach (var t in panel.Group.ActiveToggles())
                    t.isOn = false;

            switch (direct)
            {
                case MoveDirection.LeftToRight:
                    direct = MoveDirection.RightToLeft;
                    panel.Rect.DOAnchorPosX(150, 0.5f);
                    break;
                case MoveDirection.RightToLeft:
                    direct = MoveDirection.LeftToRight;
                    panel.Rect.DOAnchorPosX(-150, 0.5f);
                    break;
            }
        }
    }
}