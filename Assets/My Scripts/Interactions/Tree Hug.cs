using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHug : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("you hugged this tree");
    }
}
