using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJumpingState : CharacterBaseState
{
    public override void EnterState(CharacterStateManager character)
    {
        Debug.Log("hello from jumping state");
    }

    public override void UpdateState(CharacterStateManager character)
    {

    }

    public override void OnCollisionEnter(CharacterStateManager character)
    {

    }
}
