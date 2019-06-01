using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{
    Action ac;

    public void Init(Action action)
    {
        ac = action;
    }

    private void OnMouseDown()
    {
        ac?.Invoke();
    }
}
