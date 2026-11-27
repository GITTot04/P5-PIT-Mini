using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FruitPouch : MonoBehaviour
{
    public List<GameObject> collectedFruits = new List<GameObject>();
    public TextMeshProUGUI textComponent;
    public int totalFruit;
    GameObject winCanvas;
    void Start()
    {
        winCanvas = GameObject.Find("WinCanvas");
        winCanvas.SetActive(false);
        totalFruit = GameObject.FindGameObjectsWithTag("Fruit").Length;
        textComponent = GameObject.Find("Pouch Text").GetComponent<TextMeshProUGUI>();
        textComponent.text = $"0/{totalFruit}";
    }

    public void AddFruit(GameObject fruit)
    {
        fruit.SetActive(false);
        collectedFruits.Add(fruit);
        textComponent.text = $"{collectedFruits.Count}/{totalFruit}";
        if (collectedFruits.Count == totalFruit)
        {
            winCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
