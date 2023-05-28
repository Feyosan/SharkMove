using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport2 : MonoBehaviour
{
    TMPro.TMP_Text text;
    int count = 0;
    bool allCollected = false;

    public GameObject teleporter; // Referencia al objeto de teletransportación

    void Start() => UpdateCount();
    void OnEnable() => RequiredCollectable.OnCollected += OnCollectibleCollected;
    void OnDisable() => RequiredCollectable.OnCollected -= OnCollectibleCollected;

    void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();
        RequiredCollectable.total = 0;
    }

    void OnCollectibleCollected()
    {
        AudioSource audio = GetComponent<AudioSource>();
        count++;
        UpdateCount();
        audio.Play();

        // Verificar si se han recogido todos los objetos
        if (count == RequiredCollectable.total)
        {
            allCollected = true;
            // Activar el collider del teletransportador
            teleporter.GetComponent<Collider>().enabled = true;
        }
    }

    void UpdateCount() => text.text = $"{count} / {RequiredCollectable.total}";

    void OnTriggerEnter(Collider other)
    {
        // Verificar si se han recogido todos los objetos antes de teletransportarse
        if (allCollected)
        {
            // Teletransportarse
            other.transform.position = new Vector3(-47, 1, -2);
        }
    }


}