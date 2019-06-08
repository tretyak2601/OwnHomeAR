using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OwnHomeAR.ObjectControllers
{
    public class RotateController : ObjectController
    {
        protected override void Controll(Touch touch1, Touch touch2)
        {
            float rotateSpeed = 0.09f;
            Vector3 localAngle = controlledObject.localEulerAngles;
            localAngle.y -= rotateSpeed * touch1.deltaPosition.x;
            controlledObject.transform.localEulerAngles = localAngle;
        }
    }
}