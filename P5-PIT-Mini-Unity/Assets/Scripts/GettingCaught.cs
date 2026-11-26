using UnityEngine;

public class GettingCaught : MonoBehaviour
{
    GameObject enemy;
    GameObject loseCanvas;
    private void Start()
    {
        enemy = GameObject.Find("Enemy");
        loseCanvas = GameObject.Find("LoseCanvas");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == enemy)
        {
            loseCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
