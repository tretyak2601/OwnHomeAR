using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using OwnHomeAR.Gameplay;

namespace OwnHomeAR.UI
{
    [RequireComponent(typeof(RectTransform), typeof(ToggleGroup))]
    public abstract class SidePanel : MonoBehaviour
    {
        [SerializeField] ElementsList listPanel;
        [SerializeField] GroupPrefab groupPrefab;
        [SerializeField] ScrollRect scroll;

        public ToggleGroup Group { get; private set; }
        public RectTransform Rect { get; private set; }
        protected ElementsList ListPanel { get { return listPanel; } }

        private void Awake()
        {
            Rect = GetComponent<RectTransform>();
            Group = GetComponent<ToggleGroup>();
        }

        void Start()
        {
            foreach(ElementEnum type in Enum.GetValues(typeof(ElementEnum)))
            {
                var tempGroup = Instantiate(groupPrefab, scroll.content);
                tempGroup.Init(flag => ShowGroup(flag, type), type, Group);
            }
        }

        protected virtual void ShowGroup(bool isOn, ElementEnum type)
        {
            if (!isOn)
                return;

            int inc = Rect.anchoredPosition.x > 0 ? -1 : 1;
            InitPanel(Rect.anchoredPosition.x, inc, type);
        }

        protected abstract void InitPanel(float anchorPosX, int inc, ElementEnum type);
    }
}
