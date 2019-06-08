using OwnHomeAR.Gameplay;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OwnHomeAR.UI
{
    [Serializable]
    public class ElementUI
    {
        [SerializeField] ElementEnum type;
        [SerializeField] Sprite sprite;

        public ElementEnum Type { get { return type; } }
        public Sprite Sprite { get { return sprite; } }
    }

    [Serializable]
    public class FloorUI : ElementUI
    {
        [SerializeField] Texture2D floorTexture;
        public Texture2D FloorTexture { get { return floorTexture; } }
    }

    [Serializable]
    public class FurnitureUI : ElementUI
    {
        [SerializeField] Furniture model;
        public Furniture Model { get { return model; } }
    }
}