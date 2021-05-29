using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeyCard : MonoBehaviour
{
    public GameObject keyGrabCutscene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.Instance.HasCard = true;
            keyGrabCutscene.SetActive(true);
            
        }
    }
}
