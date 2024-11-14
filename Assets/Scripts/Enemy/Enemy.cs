using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Level { get; set; }

    void Start()
    {
        Level = 1;
    }
}
