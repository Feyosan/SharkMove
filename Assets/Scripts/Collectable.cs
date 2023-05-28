using System;
using UnityEngine;

public class Collectable : MonoBehaviour
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
