using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OwnHomeAR.ObjectControllers;
using UnityEngine.UI;
using System;

namespace OwnHomeAR.UI
{
    public class ControllesMenu : MonoBehaviour
    {
        [SerializeField] Controllers controllers;
        public Controllers Control { get { return controllers; } }
        [SerializeField] List<Toggle> toggles;

        private void OnDisable()
        {
            foreach (var t in toggles)
                t.isOn = false;
        }

        [Serializable]
        public class Controllers
        {
            [SerializeField] RotateController rotate;
            [SerializeField] MoveController move;
            [SerializeField] ScaleController scale;

            public RotateController Rotate { get { return rotate; } }
            public MoveController Move { get { return move; } }
            public ScaleController Scale { get { return scale; } }
        }
    }
}