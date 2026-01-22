using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class MagicBag : MonoBehaviour
{
    [Header("Ustawienia")]
    public int capacity = 20;
    public List<string> allowedTags = new List<string> { "BioTrash", "GlassTrash", "MetalTrash", "PlasticTrash" };

    [Header("Referencje")]
    public Transform extractionPoint;

    private List<GameObject> storedItems = new List<GameObject>();
    private XRGrabInteractable _grabInteractable;

    private void Awake()
    {
        _grabInteractable = GetComponent<XRGrabInteractable>();
    }

    private void OnEnable()
    {
        if (_grabInteractable != null)
        {
            _grabInteractable.selectEntered.AddListener(OnBagGrabbed);
            _grabInteractable.selectExited.AddListener(OnBagDropped);
        }
    }
    
    private void OnDisable()
    {
        if (_grabInteractable != null)
        {
            _grabInteractable.selectEntered.RemoveListener(OnBagGrabbed);
            _grabInteractable.selectExited.RemoveListener(OnBagDropped);
        }
    }


    private void OnBagGrabbed(SelectEnterEventArgs args)
    {
        TrashEvents.ReportBagState(true, storedItems.Count, capacity);
    }

    private void OnBagDropped(SelectExitEventArgs args)
    {
        TrashEvents.ReportBagState(false, 0, capacity);
    }

    private void UpdateBagUI()
    {
        if (_grabInteractable != null && _grabInteractable.isSelected)
        {
            TrashEvents.ReportBagState(true, storedItems.Count, capacity);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (allowedTags.Contains(other.tag) && storedItems.Count < capacity)
        {
            if (other.gameObject == this.gameObject) return;

            GameObject item = other.gameObject;
            XRGrabInteractable interactable = item.GetComponent<XRGrabInteractable>();
            if (interactable != null && interactable.isSelected) return;

            storeItem(item);
        }
    }

    private void storeItem(GameObject item)
    {
        if (storedItems.Contains(item)) return;

        storedItems.Add(item);
        item.SetActive(false);

        item.transform.SetParent(this.transform);

        Debug.Log($"Schowano: {item.name}. Razem: {storedItems.Count}");

        UpdateBagUI();
    }

    public void tryRetriveItem(XRBaseInteractor interactor)
    {
        if (storedItems.Count == 0) return;

        int randomIndex = Random.Range(0, storedItems.Count);
        GameObject itemToGive = storedItems[randomIndex];

        storedItems.RemoveAt(randomIndex);

        itemToGive.transform.SetParent(null);
        itemToGive.SetActive(true);

        itemToGive.transform.position = extractionPoint.position;
        itemToGive.transform.rotation = extractionPoint.rotation;

        Rigidbody rb = itemToGive.GetComponent<Rigidbody>();
        if (rb != null )
        {
            rb.isKinematic = false;
            rb.angularVelocity = Vector3.zero;
            rb.linearVelocity = Vector3.zero;
        }

        XRGrabInteractable grabInteractable = itemToGive.GetComponent<XRGrabInteractable>();
        if (grabInteractable != null && interactor != null) 
        {
            interactor.interactionManager.SelectEnter((IXRSelectInteractor)interactor, grabInteractable);
        }

        UpdateBagUI();
    }
}
