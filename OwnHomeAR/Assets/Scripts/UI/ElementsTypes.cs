using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OwnHomeAR.UI
{
    public class ElementsTypes : MonoBehaviour
    {
        [SerializeField] ElementType[] types;

        public static ElementsTypes Instance;
        public ElementType[] Types { get { return types; } }

        void Awake()
        {
            if (Instance)
                Destroy(gameObject);
            else
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
        }
    }

    [Serializable]
    public class ElementType
    {
        [SerializeField] ElementEnum type;
        [SerializeField] Sprite sprite;

        public ElementEnum Type { get { return type; } }
        public Sprite Sprite { get { return sprite; } }
    }
}