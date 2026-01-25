using UnityEngine;

public class TreeCollidersGenerator : MonoBehaviour
{
    public Terrain terrain;
    public float colliderRadius = 0.5f;
    public float colliderHeight = 4f;

    void Start()
    {
        TerrainData data = terrain.terrainData;
        Vector3 terrainPos = terrain.transform.position;

        foreach (TreeInstance tree in data.treeInstances)
        {
            Vector3 worldPos = Vector3.Scale(tree.position, data.size) + terrainPos;

            GameObject col = new GameObject("TreeCollider");
            col.transform.position = worldPos;

            CapsuleCollider cc = col.AddComponent<CapsuleCollider>();
            cc.radius = colliderRadius;
            cc.height = colliderHeight;
            cc.center = new Vector3(0, colliderHeight / 2f, 0);

            col.transform.parent = transform;
        }
    }
}
