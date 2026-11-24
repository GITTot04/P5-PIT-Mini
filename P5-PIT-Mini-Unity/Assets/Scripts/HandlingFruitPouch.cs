using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class HandlingFruitPouch : MonoBehaviour
{
    public XRInteractionManager xrManager;
    public IXRSelectInteractor interactor;
    public IXRSelectInteractable interactable;
    bool insideFruitPouch;
    GameObject fruitPouch;
    private void Start()
    {
        fruitPouch = GameObject.Find("Fruit Pouch");
    }

    private void Update()
    {
        if (true)
        {
            xrManager.SelectEnter(interactor,interactable);
        }
    }

    public void GrabFruitFromPouch()
    {
        FruitPouch fruitPouchComponent = fruitPouch.GetComponent<FruitPouch>();
        if (fruitPouchComponent.collectedFruits.Count > 0)
        {
            xrManager.SelectEnter(interactor, interactable);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == fruitPouch)
        {
            insideFruitPouch = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == fruitPouch)
        {
            insideFruitPouch = false;
        }
    }
}
