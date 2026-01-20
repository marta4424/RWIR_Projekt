using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class TrashNotifier : MonoBehaviour
{
    private XRGrabInteractable interactable;

    private void Awake()
    {
        interactable = GetComponent<XRGrabInteractable>();
    }

    private void OnEnable()
    {
        interactable.selectEntered.AddListener(OnGrab);
        interactable.selectExited.AddListener(OnDrop);
    }

    private void OnDisable()
    {
        interactable.selectEntered.RemoveListener(OnGrab);
        interactable.selectExited.RemoveListener(OnDrop);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        TrashEvents.ReportPickup(gameObject.tag);
    }    

    private void OnDrop(SelectExitEventArgs args)
    {
        TrashEvents.ReportDrop();
    }
}
