using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OwnHomeAR.UI
{
    public class LoadedObjects : SidePanel
    {
        protected override void ShowGroup(bool isOn, ElementEnum type)
        {
            base.ShowGroup(isOn, type);
        }

        protected override void InitPanel(float anchorPosX, int inc, ElementEnum type)
        {
            ListPanel.Init(null, anchorPosX, inc, type);
        }
    }
}