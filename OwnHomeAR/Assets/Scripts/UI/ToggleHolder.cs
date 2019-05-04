using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using DG.Tweening;

namespace OwnHomeAR.UI
{
    [RequireComponent(typeof(Toggle))]
    public abstract class ToggleHolder : MonoBehaviour
    {
        protected Toggle Toggle { get; private set; }

        protected void Awake()
        {
            Toggle = GetComponent<Toggle>();
        }
    }
}