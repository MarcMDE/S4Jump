using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEventLauncher : MonoBehaviour
{
    public event Action<Collider> OnStay;
    public event Action<Collider> OnExit;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        OnStay?.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        OnExit?.Invoke(other);
    }
}
