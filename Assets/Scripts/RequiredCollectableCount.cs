using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequiredCollectableCount : MonoBehaviour
{
   // audio source
   TMPro.TMP_Text text;
   int count = 0;

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
   }

   void UpdateCount() => text.text = $"{count} / {RequiredCollectable.total}";
}
