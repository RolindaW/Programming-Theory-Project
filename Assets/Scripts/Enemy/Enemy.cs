using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int endurance; 
    [SerializeField] protected int strength;

    protected GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    
    private void Update()
    {
        MoveTowardsPlayer();
    }

    protected abstract void MoveTowardsPlayer();
    
    protected virtual void HandleDamage(int damage)
    {
        int actualDamage = Mathf.Clamp(damage - endurance, 0, damage);
        health -= actualDamage;
    }
}
