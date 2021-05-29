using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStateActivation : MonoBehaviour
{
    public GameObject winningCutscene;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (GameManager.Instance.HasCard == true)
            {
                winningCutscene.SetActive(true);
            }
            else 
            {
                Debug.Log("You must have the KeyCard in hand");
            }
        }
    }
}
