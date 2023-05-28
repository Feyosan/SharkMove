using System.Collections.Generic;
using UnityEngine;

public class FishManager : MonoBehaviour
{
    // The list of fish Prefabs
    public List<GameObject> fishPrefabs;

    // The number of fish to instantiate
    public int numberOfFish;

    private void Start()
    {
        for (int i = 0; i < numberOfFish; i++)
        {
            // Pick a random fish prefab
            int randomIndex = Random.Range(0, fishPrefabs.Count);
            GameObject fishPrefab = fishPrefabs[randomIndex];

            // Instantiate the fish at the same position as this GameObject
            GameObject fishObject = Instantiate(fishPrefab, transform.position, Quaternion.identity);

            // Make the fish object a child of this GameObject for organization in the hierarchy
            fishObject.transform.parent = transform;
        }
    }
}