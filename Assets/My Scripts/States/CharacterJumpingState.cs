using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJumpingState : CharacterBaseState
{
    public override void EnterState(CharacterStateManager character)
    {
        //play jumping animation

    }

    public override void UpdateState(CharacterStateManager character)
    {
        Move(character);
        groundCheck(character);
    }

    public override void OnCollisionEnter(CharacterStateManager character)
    {

    }

    private void Move(CharacterStateManager character)
    {
        // Get the input values for horizontal and vertical axes
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Get the camera's forward and right vectors
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        // Make sure to disregard the y component to keep the movement in the x-z plane
        forward.y = 0f;
        right.y = 0f;

        // Normalize the vectors to ensure consistent speed in all directions
        forward.Normalize();
        right.Normalize();

        // Calculate the desired movement direction based on input and camera orientation
        Vector3 desiredMoveDirection = (forward * vertical + right * horizontal)/5;

        // Apply the movement to the player's position
        character.rb.AddForce(desiredMoveDirection, ForceMode.Force);
    }
    private void groundCheck(CharacterStateManager character)
    {
        //maybe add  previousState variable to switch back to?? idk or a default state that will go instantly to whatever it should be
        if (character.isGrounded())
        {
            character.SwitchState(character.MovingState);
        }
    }

    
}
