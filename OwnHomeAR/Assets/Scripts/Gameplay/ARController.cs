using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace OwnHomeAR.Gameplay {
    public class ARController : MonoBehaviour
    {
        [SerializeField] ARSessionOrigin session;

        public Element ElementPrefab { get; set; }

        public void Activate(bool flag, Element prefab)
        {
            ElementPrefab = prefab;
            ARSubsystemManager.planeAdded += PlaneAddedHandler;
        }

        private void PlaneAddedHandler(UnityEngine.Experimental.XR.PlaneAddedEventArgs obj)
        {
            ARSubsystemManager.planeAdded -= PlaneAddedHandler;
            Instantiate(ElementPrefab, obj.Plane.Pose.position, Quaternion.identity);
        }

        public void Test()
        {
            Instantiate(ElementPrefab, Vector3.zero, Quaternion.identity);
        }
    }
}