using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OwnHomeAR.UI
{
    [Serializable]
    public abstract class ElementsPack
    {
        [SerializeField] ElementEnum type;
        public ElementEnum Type { get { return type; } }
    }

    [Serializable]
    public class FloorPack : ElementsPack
    {
        [SerializeField] List<FloorUI> elements;
        public List<FloorUI> Elements { get { return elements; } }
    }

    [Serializable]
    public class FurniturePack : ElementsPack
    {
        [SerializeField] List<FurnitureUI> elements;
        public List<FurnitureUI> Elements { get { return elements; } }
    }
}