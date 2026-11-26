using UnityEngine;
using System.Collections;

public class Fruit : MonoBehaviour
{
    bool canBePutInPouch;
    GameObject fruitPouch;
    bool isDistraction;
    GameObject enemy;
    GameObject ground;
    [SerializeField] float distractionDistance;
    private void Start()
    {
        ground = GameObject.Find("Ground");
        enemy = GameObject.Find("Enemy");
        fruitPouch = GameObject.Find("Fruit Pouch");
    }
    public void Drop()
    {
        canBePutInPouch = true;
        StartCoroutine(ReturnToGrounded());
        isDistraction = true;
        StartCoroutine(DistractionFruit());
    }

    public IEnumerator ReturnToGrounded()
    {
        yield return new WaitForSeconds(0.5f);
        canBePutInPouch = false;
    }

    public IEnumerator DistractionFruit()
    {
        yield return new WaitForSeconds(3f);
        isDistraction = false;
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == ground && (transform.position - enemy.transform.position).magnitude < distractionDistance && isDistraction)
        {
            EnemyFollow eF = enemy.GetComponent<EnemyFollow>();
            eF.clock = 0;
            eF.lastPlayerSighting = transform.position;
            isDistraction = false;
        }
    }
}
