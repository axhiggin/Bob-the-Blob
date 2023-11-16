using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateManager : MonoBehaviour
{
    public Rigidbody rb;

    CharacterBaseState currentState;
    CharacterMovingState MovingState = new CharacterMovingState();
    CharacterJumpingState JumpingState = new CharacterJumpingState();

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        currentState = MovingState;

        currentState.EnterState(this);
    }

    void Update()
    {
        //call update in whatever state you're in
        currentState.UpdateState(this);
    }

    public void SwitchState(CharacterBaseState state)
    {
        currentState = state;
        //call enterstate in the new state
        state.EnterState(this);
    }
}
