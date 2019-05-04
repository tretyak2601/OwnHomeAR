using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace OwnHomeAR.UI
{
    public class GroupPrefab : ToggleHolder
    {
        ElementEnum elementType;

        public void Init(UnityAction<bool> action, ElementEnum type, ToggleGroup group)
        {
            Toggle.group = group;
            Toggle.onValueChanged.AddListener(action);
            elementType = type;
        }
    }
}