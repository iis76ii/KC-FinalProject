using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class interactable : MonoBehaviour
{
    //a massege displayed to the player when looking at it 
    public string promptmassege;

    // tis function is going to called by the player
    public void baseinteract()
    {
        interact();
    }

    protected virtual void interact()
    {
        // we wont have any coded written in this function 
        // this a temple function to be over ridden by our subclasses
    }
}
