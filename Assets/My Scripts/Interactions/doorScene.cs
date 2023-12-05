using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorScene : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        SceneManager.LoadScene("OutdoorScene", LoadSceneMode.Single);
        Debug.Log("press e to load next scene");
    }
}
