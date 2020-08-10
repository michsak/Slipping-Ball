using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPath : MonoBehaviour
{
    PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        if(playerMovement.GetSwitchOfPath())
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
