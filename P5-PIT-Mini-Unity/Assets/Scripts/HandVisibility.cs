using UnityEngine;

public class HandVisibility : MonoBehaviour
{
    public GameObject hand;
    public void ChangeHandVisibility()
    {
        hand.SetActive(!hand.activeSelf);
    }
}
