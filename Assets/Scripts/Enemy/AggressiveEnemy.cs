using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggressiveEnemy : Enemy
{
    [SerializeField] protected float moveSpeed;
    
    protected override void MoveTowardsPlayer()
    {
        // Constraint enemy pitch
        Vector3 lookAtPosition = new Vector3(player.transform.position.x, gameObject.transform.position.y, player.transform.position.z);
        
        // Rotate enemy
        gameObject.transform.LookAt(lookAtPosition);
        
        // Move enemy
        Vector3 movementIncrement = moveSpeed * Time.deltaTime * (lookAtPosition - gameObject.transform.position).normalized;
        gameObject.transform.Translate(movementIncrement, Space.World);
    }
}
