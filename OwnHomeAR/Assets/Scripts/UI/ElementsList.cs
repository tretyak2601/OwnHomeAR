using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OwnHomeAR.Gameplay;
using UnityEngine.UI;
using System;

namespace OwnHomeAR.UI
{
    [RequireComponent(typeof(RectTransform))]
    public class ElementsList : MonoBehaviour
    {
        [SerializeField] RectTransform rect;
        [SerializeField] ScrollRect scroll;
        [SerializeField] ElementCell cell;
        [SerializeField] ARController AR;

        [SerializeField] Floor floorPrefab;
        [SerializeField] Furniture furniturePrefab;

        List<ElementCell> elementsList = new List<ElementCell>();

        void Awake()
        {
            PanelHolder.OnToggleClicekd += () => rect.gameObject.SetActive(false);
        }

        public void Init<T>(List<T> elements, float anchPosX, int inc) where T : ElementUI
        {
            Clear();
            rect.gameObject.SetActive(true);

            foreach(var e in elements)
            {
                var tempCell = Instantiate(cell, scroll.content);
                tempCell.Init(e.Sprite, () => Implement(e));
                elementsList.Add(tempCell);
            }

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

        void Implement(ElementUI e)
        {
            rect.gameObject.SetActive(false);
            SwitchElement(e);
        }

        void SwitchElement(ElementUI eUI)
        {
            switch (eUI.Type)
            {
                case ElementEnum.Floor:
                    FloorUI fUI = eUI as FloorUI;
                    AR.Activate(true, floorPrefab, fUI.FloorTexture);
                    break;
                case ElementEnum.Furniture:
                    FurnitureUI furUI = eUI as FurnitureUI;
                    furniturePrefab = furUI.Model;
                    AR.Activate(true, furniturePrefab, furUI.Model);
                    break;
            }
        }
    }
}