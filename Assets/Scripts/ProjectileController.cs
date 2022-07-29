using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private const float MOVE_SPEED = 20.0f;

    private float xBound = 20;
    private float zBound = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy the projectile if out of bounds
        if (IsOutOfBounds())
        {
            Destroy(gameObject);
        }
        
        // Move the projectile
        gameObject.transform.Translate(MOVE_SPEED * Time.deltaTime * Vector3.forward);
    }

    private bool IsOutOfBounds()
    {
        return IsOutOfSymmetricBound(gameObject.transform.position.x, xBound) || IsOutOfSymmetricBound(gameObject.transform.position.z, zBound);
    }

    private bool IsOutOfSymmetricBound(float value, float bound)
    {
        return Math.Abs(value) > Math.Abs(bound);
    }
}
