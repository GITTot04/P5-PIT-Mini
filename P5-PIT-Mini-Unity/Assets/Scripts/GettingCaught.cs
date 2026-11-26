using UnityEngine;

public class GettingCaught : MonoBehaviour
{
    public GameObject enemy;
    GameObject loseCanvas;
    private void Start()
    {
        enemy = GameObject.Find("Enemy");
        loseCanvas = GameObject.Find("LoseCanvas");
        loseCanvas.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        if (collision.gameObject == enemy)
        {
            loseCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
