using UnityEngine;
using System.Collections;

public class Fruit : MonoBehaviour
{
    bool canBePutInPouch;
    GameObject fruitPouch;
    bool isDistraction;
    EnemyFollow enemyFollow;
    GameObject ground;
    private void Start()
    {
        ground = GameObject.Find("Ground");
        enemyFollow = GameObject.Find("Enemy").GetComponent<EnemyFollow>();
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
        if (collision.gameObject == ground && (transform.position - enemyFollow.gameObject.transform.position).magnitude <= enemyFollow.longViewDistance && isDistraction)
        {
            enemyFollow.clock = 0;
            enemyFollow.lastPlayerSighting = transform.position;
            isDistraction = false;
        }
    }
}
