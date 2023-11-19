using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterMovingState : CharacterBaseState
{
    private bool buffer;
    public override void EnterState(CharacterStateManager character)
    {
        Debug.Log("MOVE");
        buffer = true;
    }

    public override void UpdateState(CharacterStateManager character)
    {
        Move(character);
        Jump(character);
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
        Vector3 desiredMoveDirection = forward * vertical + right * horizontal;

        // Apply the movement to the player's position
        character.rb.AddForce(desiredMoveDirection, ForceMode.Force);
    }

    private void Jump(CharacterStateManager character)
    {
        if (Input.GetKeyDown(KeyCode.Space) && buffer) {
            character.rb.AddForce(0, 5, 0, ForceMode.Impulse);
            buffer = false;
            character.StartCoroutine(groundedBuffer(character));
            
        }
    }

    IEnumerator groundedBuffer(CharacterStateManager character)
    {
        yield return new WaitForSeconds(0.2f);
        character.SwitchState(character.JumpingState);
        buffer = true;
    }
}
