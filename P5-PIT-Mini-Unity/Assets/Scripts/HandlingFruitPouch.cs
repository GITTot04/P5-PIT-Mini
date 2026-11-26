using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class HandlingFruitPouch : MonoBehaviour
{
    public XRInteractionManager xrManager;
    public IXRSelectInteractor interactor;
    public bool insideFruitPouch;
    GameObject fruitPouch;
    GameObject emptyGrabable;
    private void Start()
    {
        fruitPouch = GameObject.Find("Fruit Pouch");
        emptyGrabable = GameObject.Find("Empty grabable");
    }

    public void GrabFruitFromPouch(SelectEnterEventArgs args)
    {
        if (insideFruitPouch && (Object)args.interactableObject == emptyGrabable.GetComponent<XRGrabInteractable>())
        {
            FruitPouch fruitPouchComponent = fruitPouch.GetComponent<FruitPouch>();
            int amountOfCollectedFruit = fruitPouchComponent.collectedFruits.Count;
            if (amountOfCollectedFruit > 0)
            {
                fruitPouchComponent.collectedFruits[amountOfCollectedFruit - 1].SetActive(true);
                xrManager.SelectEnter(args.interactorObject, fruitPouchComponent.collectedFruits[amountOfCollectedFruit - 1].GetComponent<XRGrabInteractable>());
                fruitPouchComponent.collectedFruits.RemoveAt(amountOfCollectedFruit - 1);
                fruitPouchComponent.textComponent.text = $"{fruitPouchComponent.collectedFruits.Count}/{fruitPouchComponent.totalFruit}";
                insideFruitPouch = false;
            }
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
