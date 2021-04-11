using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;       //initiates the Dialogue script

    public void TriggerDialogue() //function to start the game dialogue
    {
        //finds StartDialogue function in DialogueManager
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
