using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCount : MonoBehaviour
{
    // audio source
    TMPro.TMP_Text text;
    int count = 0;

    void Start() => UpdateCount();
    void OnEnable() => Collectable.OnCollected += OnCollectibleCollected;
    void OnDisable() => Collectable.OnCollected -= OnCollectibleCollected;

    void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();
        Collectable.total = 0;
    }

    void OnCollectibleCollected()
    {
        AudioSource coin = GetComponent<AudioSource>();
        count++;
        UpdateCount();
        coin.Play();
    }

    void UpdateCount() => text.text = $"{count} / {Collectable.total}";
}





