using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerAnimationController : CharacterAnimationControler
{
    private PlayerController playerController;
    protected override void Awake()
    {
        base.Awake();
        playerController = GetComponent<PlayerController>();
    }
    protected override void Update()
    {
        base.Update();
        animator.SetBool(CharacterMovementAnimationKeys.IsCrouching, characterMovement.IsCrouching);
        animator.SetFloat(CharacterMovementAnimationKeys.VerticalSpeed, characterMovement.CurrentVelocity.y / characterMovement.JumpSpeed);
        animator.SetBool(CharacterMovementAnimationKeys.IsGrounded, characterMovement.IsGrounded);
        animator.SetBool(CharacterMovementAnimationKeys.IsAttacking, playerController.Weapon.IsAttacking);
    }
}
