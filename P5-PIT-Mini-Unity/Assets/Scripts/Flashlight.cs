using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit;

public class Flashlight : MonoBehaviour
{
    public InputActionProperty switchFlashlight;
    bool equipped;
    Light flashlight;
    public float lightIntensity;
    private void Start()
    {
        GetComponent<XRGrabInteractable>().interactionManager = GameObject.Find("XR Interaction Manager").GetComponent<XRInteractionManager>();
        switchFlashlight.action.performed += OnAndOff;
        flashlight = transform.GetChild(0).gameObject.GetComponent<Light>();
        flashlight.intensity = 0;
    }

    private void OnAndOff(InputAction.CallbackContext obj)
    {
        if (equipped)
        {
            if (flashlight.intensity == 0)
            {
                flashlight.intensity = lightIntensity;
            }
            else
            {
                flashlight.intensity = 0;
            }
        }
    }

    public void Drop()
    {
        equipped = false;
        flashlight.intensity = 0;
    }

    public void Pickup()
    {
        equipped = true;
    }
}
