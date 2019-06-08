using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARFoundation;

namespace OwnHomeAR.ObjectControllers
{
    public class MoveController : ObjectController
    {
        [SerializeField] ARSessionOrigin session;

        protected override void Controll(Touch touch1, Touch touch2)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(touch1.position);
            List<ARRaycastHit> hitResults = new List<ARRaycastHit>();
            int succesNum = 0;

            if (session.Raycast(ray, hitResults, TrackableType.PlaneWithinBounds))
            {
                succesNum = hitResults.Count - 1;
                controlledObject.position = hitResults[succesNum].sessionRelativePose.position;
            }
        }
    }
}