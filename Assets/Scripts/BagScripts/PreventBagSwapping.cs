using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Filtering;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class PreventBagSwapping : MonoBehaviour, IXRSelectFilter
{
    public bool canProcess => true;

    public bool Process(IXRSelectInteractor interactor, IXRSelectInteractable interactable)
    {
        if (interactable.isSelected && !interactable.interactorsSelecting.Contains(interactor)) { return  false; }
        return true;
    }
}
