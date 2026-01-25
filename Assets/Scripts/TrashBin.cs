using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : MonoBehaviour
{
    [Header("Akceptowane Tagi")]
    public List<string> allowedTags = new List<string>();
    private Collider Collider;

    [Header("Efekty specjalne")]
    public GameObject beaconObject;
    public AudioSource soundEffect;

    [Tooltip("Ile punktów gracz dostanie za wyrzucenie œmiecia")]
    public int scorePerItem = 100;

    void OnStart()
    {
        Collider = GetComponent<Collider>();
    }

    private void OnEnable()
    {
        TrashEvents.OnTrashPickedUp += HandleTrashPickup;
        TrashEvents.OnTrashDropped += HandleTrashDrop;
    }

    private void OnDisable()
    {
        TrashEvents.OnTrashPickedUp -= HandleTrashPickup;
        TrashEvents.OnTrashDropped -= HandleTrashDrop;
    }

    private void HandleTrashPickup(string pickedUpTag)
    {
        if(allowedTags.Contains(pickedUpTag)) 
        {
            if (beaconObject != null) beaconObject.SetActive(true);
        }
    }
    
    private void HandleTrashDrop()
    {
        if (beaconObject != null) beaconObject.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (allowedTags.Contains(other.tag))
        {
            TrashEvents.ReportDrop();
            DisposeObject(other.gameObject);
        }    
    }

    private void DisposeObject(GameObject go)
    {
        if (soundEffect == null) return;

        soundEffect.Play();
        TrashEvents.ReportScore(scorePerItem);
        TrashEvents.ReportDrop();
        Debug.Log($"Zutylizowano: {go.name}");
        Destroy(go);
    }
}
