using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    
    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = new Vector3(-47, 1, -2);
    }
}

