using UnityEngine;
using System.Collections;

public class Fruit : MonoBehaviour
{
    public bool canBePutInPouch;
    GameObject fruitPouch;
    private void Start()
    {
        fruitPouch = GameObject.Find("Fruit Pouch");
    }
    public void Drop()
    {
        canBePutInPouch = true;
        StartCoroutine(ReturnToGrounded());
    }

    public IEnumerator ReturnToGrounded()
    {
        yield return new WaitForSeconds(0.5f);
        canBePutInPouch = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == fruitPouch && canBePutInPouch)
        {
            canBePutInPouch = false;
            other.gameObject.GetComponent<FruitPouch>().AddFruit(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == fruitPouch && canBePutInPouch)
        {
            canBePutInPouch = false;
            other.gameObject.GetComponent<FruitPouch>().AddFruit(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == fruitPouch && canBePutInPouch)
        {
            canBePutInPouch = false;
            other.gameObject.GetComponent<FruitPouch>().AddFruit(gameObject);
        }
    }
}
