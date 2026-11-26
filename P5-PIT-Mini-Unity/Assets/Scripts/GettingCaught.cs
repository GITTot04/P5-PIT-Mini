using UnityEngine;

public class GettingCaught : MonoBehaviour
{
    public GameObject enemy;
    GameObject loseCanvas;
    float killRange = 1.5f;
    private void Start()
    {
        enemy = GameObject.Find("Enemy");
        loseCanvas = GameObject.Find("LoseCanvas");
        loseCanvas.SetActive(false);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, enemy.transform.position) < killRange)
        {
            loseCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
