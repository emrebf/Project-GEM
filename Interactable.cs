using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool talks;      // if true, the player can talk to this interactable
    public string message;  //the dialogue
    public Rigidbody2D rb2;

    public void DoInteraction() //function to perform the interaction
    {
        //dialogue is sent
        gameObject.SetActive(false);
    }

    public void Talk()
    {
        Debug.Log(message);
    }
    
}
