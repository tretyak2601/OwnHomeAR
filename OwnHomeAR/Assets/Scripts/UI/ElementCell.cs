using OwnHomeAR.Gameplay;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace OwnHomeAR.UI
{
    [RequireComponent(typeof(Image), typeof(Button))]
    public class ElementCell : MonoBehaviour
    {
        int dragCount = default;
        bool choosed = default;

        public Image Image { get; private set; }
        public Button Button { get; private set; }

        public event Action<Vector2> OnElementChoosed;
        Element element;

        void Awake()
        {
            Image = GetComponent<Image>();
            Button = GetComponent<Button>();
        }

        public void Init(ElementEnum type, UnityAction action)
        {
            Image.sprite = Array.Find(ElementsTypes.Instance.Types, t => t.Type == type).Sprite;
            Button.onClick.AddListener(action);
        }
    }
}