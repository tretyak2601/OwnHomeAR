using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using OwnHomeAR.UI;
using UnityEngine.Events;

namespace OwnHomeAR.Gameplay
{
    public class ARController : MonoBehaviour
    {
        [SerializeField] ARSessionOrigin session;

        public Element ElementPrefab { get; set; }
        Object elementObject;

        public void Activate(bool flag, Element el, Object obj)
        {
            ElementPrefab = el;
            elementObject = obj;
#if !UNITY_EDITOR
            ARSubsystemManager.planeAdded += PlaneAddedHandler;
#else
            Test();
#endif
        }

        private void PlaneAddedHandler(UnityEngine.Experimental.XR.PlaneAddedEventArgs obj)
        {
            ARSubsystemManager.planeAdded -= PlaneAddedHandler;
            Instantiate(ElementPrefab, obj.Plane.Pose.position, Quaternion.identity).InitElement(elementObject);
        }

        public void Test()
        {
            var fl = Instantiate(ElementPrefab, Vector3.zero, Quaternion.identity);
            fl.InitElement(elementObject);
            fl.transform.localEulerAngles = new Vector3(-90, 0, 0);
            fl.transform.localPosition = new Vector3(0, 0, 30);
        }
    }
}