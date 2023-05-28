using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequiredCollectable : MonoBehaviour
{
    public static event Action OnCollected;
    public static int total = 0;

    private void Start()
    {
        total++;
    }
    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(0f, Time.time * 100f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnCollected?.Invoke();
            Destroy(gameObject);
        }
    }
}
