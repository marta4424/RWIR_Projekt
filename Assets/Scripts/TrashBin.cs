using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : MonoBehaviour
{
    [Header("Akceptowane Tagi")]
    public List<string> allowedTags = new List<string>();
    private Collider Collider;

    //mo¿na dodaæ audio odtwarzane przy wyrzuceniu
    //ewentualnie jeszcze particle

    void OnStart()
    {
        Collider = GetComponent<Collider>();
    }    

    private void OnTriggerEnter(Collider other)
    {
        if (allowedTags.Contains(other.tag))
        {
            DisposeObject(other.gameObject);
        }    
    }

    private void DisposeObject(GameObject go)
    {
        Debug.Log($"Zutylizowano: {go.name}");
        Destroy(go);
    }
}
