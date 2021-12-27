using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : CharacterAnimationControler
{
    private EnemyAIControler enemyAI;
    protected override void Awake()
    {
        base.Awake();
        enemyAI = GetComponent<EnemyAIControler>();
    }
    protected override void Update()
    {
        base.Update();
        animator.SetBool(EnemyAnimationKeys.isChasing, enemyAI.IsChasing);
    }
}
