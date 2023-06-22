using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    public LayerMask LayerMask;
    public GameObject TrackPrefab;
    public int maxObject;
    public Transform pool;
    private List<GameObject> PrefabObjects = new List<GameObject>();
    private void OnTriggerEnter(Collider other)
    {
        PrefabObjects.Add(Instantiate(TrackPrefab, transform.position, transform.rotation, pool));
        if (PrefabObjects.Count > maxObject)
        {
            Destroy(PrefabObjects[0]);
            PrefabObjects.RemoveAt(0);
        }
    }
}
