using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    
    public string NPCname;      //NPC name variable

    [TextArea(3, 10)]           //min and max amount of sentences
    public string[] sentences; //array of sentences
}
