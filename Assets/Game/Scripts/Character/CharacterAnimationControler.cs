using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.Character;



public static class CharacterMovementAnimationKeys
{
    public const string IsCrouching = "isCrouching";
    public const string HorizontalSpeed = "HorizontalSpeed";
    public const string VerticalSpeed = "VerticalSpeed";
    public const string IsGrounded = "isGrounded";
    public const string TriggerDead = "Dead";
    public const string IsAttacking = "IsAttacking";
}

public static class EnemyAnimationKeys
{
    public const string isChasing = "isChasing";
}


[RequireComponent(typeof(Animator))]
public class CharacterAnimationControler : MonoBehaviour
{
    protected Animator animator;
    protected CharacterMovement2D characterMovement;
    private IDamageable damageable;

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        characterMovement = GetComponent<CharacterMovement2D>();

        damageable = GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.DeathEvent += OnDeath;
        }
    }

    private void OnDestroy()
    {
        if (damageable != null)
        {
            damageable.DeathEvent -= OnDeath;
        }
    }
    private void OnDeath()
    {
        animator.SetTrigger(CharacterMovementAnimationKeys.TriggerDead);
    }

    protected virtual void Update()
    {
        animator.SetFloat(CharacterMovementAnimationKeys.HorizontalSpeed, characterMovement.CurrentVelocity.x / characterMovement.MaxGroundSpeed);
    }
}
