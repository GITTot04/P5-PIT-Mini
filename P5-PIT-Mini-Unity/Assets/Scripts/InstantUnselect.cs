using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
public class InstantUnselect : MonoBehaviour
{
    public XRInteractionManager xrManager;
    IXRSelectInteractor interactor;
    public void UnSelect() 
    {
        xrManager.SelectExit(interactor, gameObject.GetComponent<XRGrabInteractable>());
    }
}
