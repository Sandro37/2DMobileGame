using BBUnity.Conditions;
using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Condition("Game/Perception/IsTargetVisible")]
public class IsTargetVisible : GOCondition
{
    [InParam("target")]
    private GameObject target;

    [InParam("AIVision")]
    private AIVision aiVision;

    [InParam("TargetMemoryDuration")]
    private float targetMemoryDuration;

    private float forgetTargetTime;
    public override bool Check()
    {
        bool isAvailable = IsAvailable();
        if (aiVision.IsVisible(target) && isAvailable)
        {
            forgetTargetTime = Time.time + targetMemoryDuration;
            return true;
        }

        return Time.time < forgetTargetTime && isAvailable;
    }

    private bool IsAvailable()
    {
        if(target == null)
        {
            return false;
        }

        //TODO: Não chamar GetComponent no update
        IDamageable damageable = target.GetComponent<IDamageable>();

        if(damageable != null)
        {
            return !damageable.IsDead;
        }

        return true;
    }
}
