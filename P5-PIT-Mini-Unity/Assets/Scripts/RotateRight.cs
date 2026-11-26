using UnityEngine;

public class RotateRight : MonoBehaviour
{
    public GameObject thisObject;
    void Start()
    {
        Vector3 rotation = thisObject.transform.rotation.eulerAngles;
        rotation.x += 90;
        rotation.y -= 90;
        this.gameObject.transform.rotation = Quaternion.Euler(rotation);
    }
    public void Update()
    {
        
    }

}
