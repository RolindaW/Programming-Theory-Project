using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HinderingEnemy : Enemy
{
    protected override void MoveTowardsPlayer()
    {
        // Constraint enemy pitch
        Vector3 lookAtPosition = new Vector3(player.transform.position.x, gameObject.transform.position.y, player.transform.position.z);
        
        // Rotate enemy
        gameObject.transform.LookAt(lookAtPosition);
    }
}
