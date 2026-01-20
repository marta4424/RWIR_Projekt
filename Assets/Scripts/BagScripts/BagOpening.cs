using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class BagOpening : MonoBehaviour
{
    public MagicBag magicBag;

    private XRSimpleInteractable interactable;

    private void Awake()
    {
        interactable = GetComponent<XRSimpleInteractable>();
    }

    private void OnEnable()
    {
        interactable.selectEntered.AddListener(OnGrabItem);
        interactable.hoverEntered.AddListener(OnHoverStart);
    }
    
    private void OnDisable()
    {
        interactable.selectEntered.RemoveListener(OnGrabItem);
        interactable.hoverEntered.RemoveListener(OnHoverStart);
    }

    private void OnHoverStart(HoverEnterEventArgs args)
    {
        Debug.Log("Widzê otwór");
    }

    private void OnGrabItem(SelectEnterEventArgs args)
    {
        Debug.Log("Proba chwytu w worku");
        XRBaseInteractor hand = args.interactorObject as XRBaseInteractor;

        if (magicBag != null)
        {
            magicBag.tryRetriveItem(hand);
        }
    }
}
