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
    private void Start()
    {
        fruitPouch = GameObject.Find("Fruit Pouch");
    }

    public void GrabFruitFromPouch()
    {
        Debug.Log("Tried to grab");
        if (insideFruitPouch)
        {
            Debug.Log("Tried to grab inside pouch");
            FruitPouch fruitPouchComponent = fruitPouch.GetComponent<FruitPouch>();
            int amountOfCollectedFruit = fruitPouchComponent.collectedFruits.Count;
            if (amountOfCollectedFruit > 0)
            {
                Debug.Log("Tried to grab fruit inside pouch");
                fruitPouchComponent.collectedFruits[amountOfCollectedFruit - 1].SetActive(true);
                xrManager.SelectEnter(interactor, fruitPouchComponent.collectedFruits[amountOfCollectedFruit - 1].GetComponent<XRGrabInteractable>());
                fruitPouchComponent.collectedFruits.RemoveAt(amountOfCollectedFruit - 1);
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
