﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OwnHomeAR.Gameplay;
using UnityEngine.UI;

namespace OwnHomeAR.UI
{
    [RequireComponent(typeof(RectTransform))]
    public class ElementsList : MonoBehaviour
    {
        [SerializeField] RectTransform rect;
        [SerializeField] ScrollRect scroll;

        List<Element> elementsList = new List<Element>();

        void Awake()
        {
            PanelHolder.OnToggleClicekd += () => rect.gameObject.SetActive(false);
        }

        public void Init(List<Element> elements, float anchPosX, int inc)
        {
            Clear();
            rect.gameObject.SetActive(true);

            rect.anchoredPosition = new Vector2(anchPosX * 2 + Screen.currentResolution.height * inc, 0);

            Vector2 ofMin = inc < 0 ? new Vector2(anchPosX * 2, 0) : Vector2.zero;
            Vector2 ofMax = inc < 0 ? Vector2.zero : new Vector2(anchPosX * 2, 0);

            rect.offsetMin = inc < 0 ? new Vector2(anchPosX * 2, 0) : Vector2.zero;
            rect.offsetMax = inc < 0 ? Vector2.zero : new Vector2(anchPosX * 2, 0);
        }

        void Clear()
        {
            scroll.content.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            rect.anchoredPosition = Vector2.zero;
            elementsList.ForEach(elm => Destroy(elm.gameObject));
            elementsList.Clear();
        }
    }
}