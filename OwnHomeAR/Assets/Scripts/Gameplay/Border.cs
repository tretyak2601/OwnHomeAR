using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OwnHomeAR.Gameplay
{
    public class Border : MonoBehaviour
    {
        [SerializeField] BorderPosition borderPos;
        [SerializeField] float scaleSpeed = 6;

        Transform parent;
        const float FULL_SIZE = 1f;
        const float STANDART_SIZE = 1f;
        const float BORDER_POSITION = 5f;
        const float FEW_UP = 0.1f;

        Vector3 lastPos;
        Vector3 deltaPos;

        public void InitBorder(Transform parent, float scaleSpeed)
        {
            this.parent = parent;
            this.scaleSpeed = scaleSpeed;
        }

        public void UpdateSize()
        {
            switch (borderPos)
            {
                case BorderPosition.Right:
                    transform.localScale = new Vector3(0.1f / parent.localScale.x, STANDART_SIZE, FULL_SIZE);
                    transform.localPosition = new Vector3(BORDER_POSITION, FEW_UP, 0);
                    break;
                case BorderPosition.Up:
                    transform.localScale = new Vector3(FULL_SIZE, STANDART_SIZE, FEW_UP / parent.localScale.z);
                    transform.localPosition = new Vector3(0, FEW_UP, BORDER_POSITION);
                    break;
                case BorderPosition.Down:
                    transform.localScale = new Vector3(FULL_SIZE, STANDART_SIZE, FEW_UP / parent.localScale.z);
                    transform.localPosition = new Vector3(0, FEW_UP, -BORDER_POSITION);
                    break;
                case BorderPosition.Left:
                    transform.localScale = new Vector3(0.1f / parent.localScale.x, STANDART_SIZE, FULL_SIZE);
                    transform.localPosition = new Vector3(-BORDER_POSITION, FEW_UP, 0);
                    break;
            }
        }

        public void OnMouseDrag()
        {
            if (lastPos == Vector3.zero)
            {
                lastPos = Input.mousePosition;
                return;
            }

            float delta = default;
            deltaPos = Input.mousePosition - lastPos;
            lastPos = Input.mousePosition;
            
            switch (borderPos)
            {
                case BorderPosition.Up:
                    delta = deltaPos.y;
                    parent.localScale += new Vector3(0, 0, delta  / scaleSpeed);
                    parent.localPosition += new Vector3(0, 0, delta / (scaleSpeed / 5));
                    break;
                case BorderPosition.Down:
                    delta = deltaPos.y;
                    parent.localScale -= new Vector3(0, 0, delta / scaleSpeed);
                    parent.localPosition += new Vector3(0, 0, delta  / (scaleSpeed / 5));
                    break;
                case BorderPosition.Right:
                    delta = deltaPos.x;
                    parent.localScale += new Vector3(delta  / scaleSpeed, 0, 0);
                    parent.localPosition += new Vector3(delta  / (scaleSpeed / 5), 0, 0);
                    break;
                case BorderPosition.Left:
                    delta = deltaPos.x;
                    parent.localScale -= new Vector3(delta  / scaleSpeed, 0, 0);
                    parent.localPosition += new Vector3(delta / (scaleSpeed / 5), 0, 0);
                    break;
            }
        }

        private void OnMouseUp()
        {
            deltaPos = Vector3.zero;
            lastPos = Vector3.zero;
        }
    }

    public enum BorderPosition
    {
        Up,
        Down,
        Left,
        Right
    }
}