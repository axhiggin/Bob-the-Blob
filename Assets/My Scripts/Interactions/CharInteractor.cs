using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

interface IInteractable
{
    public void Interact();
}
public class CharInteractor : MonoBehaviour
{
    public Transform Interactor;
    public float InteractRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            Collider[] colliders = Physics.OverlapSphere(Interactor.position, InteractRange);
            foreach (Collider collider in colliders)
            {
                if (collider.gameObject.TryGetComponent(out IInteractable interactable))
                {
                    interactable.Interact();
                }
            }
        }
    }
}
