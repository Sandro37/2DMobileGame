using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.Character;


[RequireComponent(typeof(CharacterMovement2D))]
[RequireComponent(typeof(CharacterFacing2D))]
[RequireComponent(typeof(IDamageable))]
public class EnemyAIControler : MonoBehaviour
{

    private CharacterMovement2D enemyMovement;
    private Vector2 movementInput;
    private CharacterFacing2D enemyFacing;
    private bool isChasing;
    IDamageable damageable;
    [SerializeField] private TriggerDamage damage;

    public bool IsChasing
    {
        get => isChasing;
        set => isChasing = value;
    }
    public Vector2 MovementInput
    {
        get => movementInput;
        set => movementInput = new Vector2(Mathf.Clamp(value.x, -1,1), Mathf.Clamp(value.y, -1, 1));
    }
    // Start is called before the first frame update
    void Start()
    {
        enemyMovement = GetComponent<CharacterMovement2D>();
        enemyFacing = GetComponent<CharacterFacing2D>();
        damageable = GetComponent<IDamageable>();
        damageable.DeathEvent += OnDeath;
    }

    private void OnDestroy()
    {
        if(damageable != null)
        {
            damageable.DeathEvent -= OnDeath;
        }
    }
    // Update is called once per frame
    void Update()
    {
        enemyMovement.ProcessMovementInput(movementInput);
        enemyFacing.UpdateFacing(movementInput);
    }

    private void OnDeath()
    {
        enabled = false;
        enemyMovement.StopImmediately();
        damage.gameObject.SetActive(false);
        Destroy(gameObject, 0.667f);
    }
}
