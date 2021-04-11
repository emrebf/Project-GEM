using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    //Emily Flood
    //code is inspired by Scripting is Fun's playlist on Unity 2D Game Basics
    //https://www.youtube.com/watch?v=gGUtoy4Knnw&list=PLa5_l08N9jzN6RpyixHkXP90IW6gaVVV1&index=10


    public GameObject currentInterObj = null;
    public Interactable currentInterObjScript = null;
    public void PickupItem(GameObject obj)
    {
        
    }

    void Update()
    {
        if(Input.GetButtonDown ("Interact") && currentInterObj) //checks for interaction between player and obj
        {
            //object interaction
            currentInterObj.SendMessage("DoInteraction"); //tells Interactable.cs to call DoInteraction
        }

        
    }
    void OnTriggerEnter2D(Collider2D other) //if the player hits the NPC collider
    {
        if(other.CompareTag("interObject"))
        {
            Debug.Log(other.name);
            currentInterObj = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other) //if the player leaves the NPC collider
    {
        if (other.CompareTag("interObject"))
        {
            if (other.gameObject == currentInterObj)
            {
                currentInterObj = null;
            }
        }
    }
}

