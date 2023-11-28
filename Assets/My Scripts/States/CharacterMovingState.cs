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
        Vector3 inputDirection = new Vector3(horizontal, 0f, vertical).normalized;

        // Get the camera's forward and right vectors
        inputDirection = Camera.main.transform.TransformDirection(inputDirection);
        inputDirection.y = 0;

        character.rb.AddForce(inputDirection * character.speed, ForceMode.Acceleration);

        Vector3 clampedVelocity = character.rb.velocity;
        clampedVelocity.x = Mathf.Clamp(clampedVelocity.x, -character.maxSpeed, character.maxSpeed);
        clampedVelocity.z = Mathf.Clamp(clampedVelocity.z, -character.maxSpeed, character.maxSpeed);
        character.rb.velocity = clampedVelocity;
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
