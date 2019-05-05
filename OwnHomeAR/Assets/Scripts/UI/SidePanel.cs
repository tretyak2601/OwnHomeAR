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
        [SerializeField] ElementsPack[] packs;

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
                tempGroup.Init(flag => ShowGroup(flag, Array.Find(packs, pack => type == pack.Type).elements), type, Group);
            }
        }

        protected virtual void ShowGroup(bool isOn, List<Element> elements)
        {
            if (!isOn)
                return;

            int inc = Rect.anchoredPosition.x > 0 ? -1 : 1;
            listPanel.Init(elements, Rect.anchoredPosition.x, inc);
        }
    }

    [Serializable]
    class ElementsPack
    {
        [SerializeField] ElementEnum type;
        [SerializeField] public List<Element> elements;

        public ElementEnum Type { get { return type; } }
        public List<Element> Elements { get { return elements; } }
    }
}
