using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //Emily Flood
    //code inspired by Brackey's YouTube tutorial on Dialogue Systems in Unity
    //https://www.youtube.com/watch?v=_nRzoTzeyxU

    //initializing variables for name text and dialogue text
    public Text nameText;
    public Text dialogueText;

    public Animator boxAnim;        //initializing animator
    
    public Queue<string> sentences;      //stores dialogue

    void Start()
    {
        sentences = new Queue<string>();    //loads sentences
    }
    
    public void StartDialogue (Dialogue dialogue) //calls from the Dialogue script
    {
        boxAnim.SetBool("IsOpen", true);        //sets the animator to the box being open

        nameText.text = dialogue.NPCname;   //displays name text

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)      //for each sentence in "sentences"
        {
            sentences.Enqueue(sentence);        //displays sentences in order in the queue
        }

        DisplayNextSentence();      //goes to display the next sentence once dialogue is started
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();      //if there is no more dialogue, finished
            return;
        }

        string sentence = sentences.Dequeue(); //displays next sentence
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence)); //types out sentence
    }

    IEnumerator TypeSentence (string sentence)
    {
        //sets the letters in an array so it can type them out one by one
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) 
        {
            dialogueText.text += letter;        //types out the letters
            yield return null;
        }
    }

    void EndDialogue()      //function to end dialogue
    {
        boxAnim.SetBool("IsOpen", false);   //sets the animator to the box being closed
    }
}
