using Unity.VisualScripting;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    [Header("Ustawienia œmieci")]
    public GameObject[] trashPrefabs;
    public int trashNum;

    [Header("Ustawienia obszaru")]
    public Collider spawnArea;
    public LayerMask terrainLayer;

    void Start()
    {
        SpawnAllTrash();
    }

    void SpawnAllTrash()
    {
        for (int i = 0; i < trashNum; i++) 
        {
            SpawnSingleTrash();
        }
    }

    void SpawnSingleTrash() 
    {
        if (spawnArea == null) 
        {
            Debug.Log("SpawnArea not assigned!");
            return;
        }

        Bounds bounds = spawnArea.bounds;

        float randX = Random.Range(bounds.min.x, bounds.max.x);
        float randZ = Random.Range(bounds.min.z, bounds.max.z);

        Vector3 rayOrigin = new Vector3(randX, bounds.max.y + 10f, randZ);

        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, Vector3.down, out hit, 200f, terrainLayer)) 
        {
            GameObject randTrash = trashPrefabs[Random.Range(0, trashPrefabs.Length)];
            Quaternion randRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            Instantiate(randTrash, hit.point + Vector3.up * 0.5f, randRotation, transform);
        }
    }
}
