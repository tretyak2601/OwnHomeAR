using OwnHomeAR.Gameplay;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace OwnHomeAR.UI
{
    public class GroupPrefab : ToggleHolder
    {
        [SerializeField] Image Checkmark;
        List<Element> elementItems;

        public void Init(UnityAction<bool> action, ElementEnum type, ToggleGroup group)
        {
            Toggle.group = group;
            Toggle.onValueChanged.AddListener(action);
            ElementType elementType = Array.Find(ElementsTypes.Instance.Types, t => t.Type == type);
            Toggle.image.sprite = elementType.Sprite;
            Checkmark.color = Color.black;
            Checkmark.sprite = elementType.Sprite;
        }
    }
}