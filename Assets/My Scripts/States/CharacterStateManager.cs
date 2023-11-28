using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateManager : MonoBehaviour
{
    //for movement
    [SerializeField] public float speed = 5f;
    [SerializeField] public float maxSpeed = 6f;
    [SerializeField] public float rotationSpeed = 1.0f;

    public Rigidbody rb;
    private Collider col;
    public Camera cam;

    //ground checking
    private float groundDist;

    CharacterBaseState currentState;
    public CharacterMovingState MovingState = new CharacterMovingState();
    public CharacterJumpingState JumpingState = new CharacterJumpingState();



    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //get components from the scene
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();

        //initialize first state
        currentState = MovingState;

        currentState.EnterState(this);

        //ground distance
        groundDist = col.bounds.extents.y;

    }

    void Update()
    {
        //call update in whatever state you're in
        currentState.UpdateState(this);
        /*Debug.Log(isGrounded());*/
    }

    public void SwitchState(CharacterBaseState state)
    {
        currentState = state;
        //call enterstate in the new state
        state.EnterState(this);
    }

    public bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, groundDist);

    }

}
