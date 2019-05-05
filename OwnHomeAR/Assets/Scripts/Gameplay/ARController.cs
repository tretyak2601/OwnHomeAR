using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARController : MonoBehaviour
{
    [SerializeField] ARSessionOrigin session;
    [SerializeField] GameObject planePrefab;

    private void Awake()
    {
        ARSubsystemManager.planeAdded += PlaneAddedHandler;
    }

    private void PlaneAddedHandler(UnityEngine.Experimental.XR.PlaneAddedEventArgs obj)
    {
        ARSubsystemManager.planeAdded -= PlaneAddedHandler;
        Instantiate(planePrefab, obj.Plane.Pose.position, Quaternion.identity);
    }
}
