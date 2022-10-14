using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad_OBJ : MonoBehaviour
{
    void Awake()
    { DontDestroyOnLoad(this); }
}
