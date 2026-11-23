using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit;

public class Flashlight : MonoBehaviour
{
    bool equipped;
    Light flashlight;
    public float lightIntensity;
    Transform defaultPosition;
    private void Start()
    {
        GetComponent<XRGrabInteractable>().interactionManager = GameObject.Find("XR Interaction Manager").GetComponent<XRInteractionManager>();
        flashlight = transform.GetChild(0).gameObject.GetComponent<Light>();
        flashlight.intensity = 0;
        defaultPosition = GameObject.Find("Flashlight location").GetComponent<Transform>();
        transform.SetParent(defaultPosition, false);
        transform.localScale = Vector3.one;
        transform.localPosition = Vector3.zero;
    }

    public void FlashlightToggle()
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
        transform.SetParent(defaultPosition, false);
        transform.localScale = Vector3.one;
        transform.position = defaultPosition.position;
    }

    public void Pickup()
    {
        equipped = true;
        transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        transform.SetParent(null, true);
    }
}
