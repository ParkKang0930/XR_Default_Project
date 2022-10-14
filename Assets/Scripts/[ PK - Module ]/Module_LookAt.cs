using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module_LookAt : MonoBehaviour
{
    public Transform[] Target;

    void Update()
    {
        for (int i = 0; i < Target.Length; i++)
        {
            if (Target[i].gameObject.activeSelf == true)
                Target[i].rotation = Quaternion.LookRotation(Target[i].position - Camera.main.transform.position);
        }
    }
}
