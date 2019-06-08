using OwnHomeAR.ObjectControllers;
using OwnHomeAR.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OwnHomeAR.Gameplay
{
    public class Furniture : Element
    {
        public override void InitElement(UnityEngine.Object obj, Action<bool> showMenuAction, Transform parentScale, ControllesMenu.Controllers control)
        {
            base.InitElement(obj, showMenuAction, parentScale, control);
        }
    }
}
