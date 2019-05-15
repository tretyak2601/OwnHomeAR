using OwnHomeAR.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OwnHomeAR.UI
{
    public class LoadedObjects : SidePanel
    {
        protected override void ShowGroup<T>(bool isOn, List<T> elements)
        {
            base.ShowGroup(isOn, elements);
        }
    }
}