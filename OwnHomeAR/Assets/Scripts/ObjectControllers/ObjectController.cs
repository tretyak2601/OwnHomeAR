using OwnHomeAR.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OwnHomeAR.ObjectControllers
{
    [RequireComponent(typeof(Toggle))]
    public abstract class ObjectController : MonoBehaviour
    {
        protected Transform controlledObject;
        Toggle toggle;

        protected float deltaStart;
        protected float deltaCurrent;

        public virtual void InitController(Transform controlledObject, Element element)
        {
            this.controlledObject = controlledObject;
        }

        protected abstract void Controll(Touch touch1, Touch touch2);
        void Start() => toggle = GetComponent<Toggle>();

        void Update()
        {
            if (!toggle.isOn)
                return;

            if (Input.touchCount == 2)
                Controll(Input.GetTouch(0), Input.GetTouch(1));
            else
            {
                deltaStart = 0;
                deltaCurrent = 0;
            }
        }
    }
}