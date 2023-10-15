using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyListener : MonoBehaviour
{
    public delegate void OnDestroyCallback();

    public event OnDestroyCallback OnDestroyEvent;

    void OnDestroy()
    {
        if (OnDestroyEvent != null)
        {
            OnDestroyEvent.Invoke();
        }
    }
}