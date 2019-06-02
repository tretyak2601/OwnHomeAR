using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OwnHomeAR.ObjectControllers
{
    public class ScaleController : ObjectController
    {
        protected override void Controll(Touch touch1, Touch touch2)
        {
            Vector2 touchZeroPrevPos = touch1.position - touch1.deltaPosition;
            Vector2 touchOnePrevPos = touch2.position - touch2.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touch1.position - touch2.position).magnitude;

            float delta = prevTouchDeltaMag - touchDeltaMag;
            delta /= -3000;

            controlledObject.localScale += new Vector3(delta, delta, delta);

            if (controlledObject.localScale.x < 0 || controlledObject.localScale.y < 0 || controlledObject.localScale.z < 0)
                controlledObject.localScale = Vector3.zero;
        }
    }
}