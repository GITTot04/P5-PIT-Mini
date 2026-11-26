using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit;
public class InstantUnselect : MonoBehaviour
{
    public XRInteractionManager xrManager;
    public void UnSelect(SelectEnterEventArgs args) 
    {
        xrManager.SelectExit(args.interactorObject, gameObject.GetComponent<XRGrabInteractable>());
    }
}
