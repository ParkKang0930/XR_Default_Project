using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Module_ColEvents : MonoBehaviour
{
    public UnityEvent Enter;
    public UnityEvent Exit;

    bool IsOn = false;

    private void Start()
    {
        StartCoroutine(SetBool());
    }
    void OnTriggerEnter(Collider other)
    { 
        if(other.gameObject.layer == 3 && IsOn) Enter.Invoke();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 3) Exit.Invoke();
    }

    IEnumerator SetBool()
    {
        IsOn = false;
        yield return new WaitForSeconds(0.5f);
        IsOn = true;
    }
}
