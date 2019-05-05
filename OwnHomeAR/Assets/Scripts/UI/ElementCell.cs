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

        void Awake()
        {
            Image = GetComponent<Image>();
            Button = GetComponent<Button>();
        }

        public void Init(Sprite spr, UnityAction action)
        {
            Image.sprite = spr;
            Button.onClick.AddListener(action);
        }
    }
}