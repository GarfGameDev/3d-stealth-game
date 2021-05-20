using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public Transform MyCamera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("The player has collided with a trigger");
            Camera.main.transform.position = MyCamera.transform.position;
            Camera.main.transform.rotation = MyCamera.transform.rotation;
        }
    }
}
