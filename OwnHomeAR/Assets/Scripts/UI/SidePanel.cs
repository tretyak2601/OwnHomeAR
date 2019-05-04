using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

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
                tempGroup.Init(ShowGroup, type, Group);
            }
        }

        void ShowGroup(bool isOn)
        {
            if (!isOn)
                return;

            int inc = Rect.anchoredPosition.x > 0 ? -1 : 1;
            listPanel.Init(null, Rect.anchoredPosition.x, inc);
        }
    }
}
