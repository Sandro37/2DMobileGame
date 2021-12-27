using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using Platformer2D.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("Game/Patrol")]
public class Patrol : BasePrimitiveAction
{
    [InParam("AIController")]
    private EnemyAIControler enemyAI;

    [InParam("patrolSpeed")]
    private float patrolSpeed;

    [InParam("CharacterMovement")]
    private CharacterMovement2D charMovement;
    public override void OnStart()
    {
        base.OnStart();
        enemyAI.StartCoroutine(TEMP_Walk());
        charMovement.MaxGroundSpeed = patrolSpeed;
    }

    public override TaskStatus OnUpdate()
    {
        return TaskStatus.RUNNING;
    }

    public override void OnAbort()
    {
        base.OnAbort();

        // TODO: Remover coroutine
        enemyAI.StopAllCoroutines();
    }
    IEnumerator TEMP_Walk()
    {
        while (true)
        {

            enemyAI.MovementInput = new Vector2(1, 0);
            yield return new WaitForSeconds(1.0f);
            enemyAI.MovementInput = new Vector2(0, 0);
            yield return new WaitForSeconds(2.0f);
            enemyAI.MovementInput = new Vector2(-1, 0);
            yield return new WaitForSeconds(1.0f);
            enemyAI.MovementInput = new Vector2(0, 0);
            yield return new WaitForSeconds(2.0f);
        }
    }
}
