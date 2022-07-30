using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private const float MOVE_SPEED = 20.0f;

    [SerializeField] private int _damage;
    
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
        float xBound = 20.0f;
        float zBound = 20.0f;
        
        return IsOutOfSymmetricBound(gameObject.transform.position.x, xBound) || IsOutOfSymmetricBound(gameObject.transform.position.z, zBound);
    }

    private bool IsOutOfSymmetricBound(float value, float bound)
    {
        return Math.Abs(value) > Math.Abs(bound);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.HandleDamage(_damage);
        }
        
        Destroy(gameObject);
    }
}
