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

        [SerializeField] FloorPack floorPack;
        [SerializeField] FurniturePack furniturePack;

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
                GroupPrefab tempGroup = Instantiate(groupPrefab, scroll.content);

                switch (type)
                {
                    case ElementEnum.Floor:
                        tempGroup.Init(flag => ShowGroup(flag, floorPack.Elements), type, Group);
                        break;
                    case ElementEnum.Furniture:
                        tempGroup.Init(flag => ShowGroup(flag, furniturePack.Elements), type, Group);
                        break;
                }
            }
        }

        protected virtual void ShowGroup<T>(bool isOn, List<T> elements) where T : ElementUI
        {
            if (!isOn)
                return;

            int inc = Rect.anchoredPosition.x > 0 ? -1 : 1;
            listPanel.Init(elements, Rect.anchoredPosition.x, inc);
        }
    }
}
