using UnityEngine;

public class FogHandler : MonoBehaviour
{
    [SerializeField] GameObject player;

    void FixedUpdate()
    {
        transform.position = player.transform.position;
    }
}
