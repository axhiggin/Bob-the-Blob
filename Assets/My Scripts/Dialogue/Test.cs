using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private GameObject visualCue;
    private bool inRange;

    [SerializeField] private TextAsset inkJSON;
    // Start is called before the first frame update
    void Start()
    {
        visualCue.SetActive(false);
        inRange = false;
    }

    // Update is called once per frame
    private void Update()
    {
        visualCue.SetActive(inRange);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Bob")
        {
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Bob")
        {
            inRange = false;
        }
    }
}
