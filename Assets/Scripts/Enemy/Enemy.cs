using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int _health;
    [SerializeField] protected int _endurance; 
    [SerializeField] protected int _damage;
    [SerializeField] protected int _score;

    protected GameObject player;
    
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        player = GameObject.FindWithTag("Player");
    }
    
    private void FixedUpdate()
    {
        if (gameManager.IsGameActive)
        {
            MoveTowardsPlayer();
        }
    }

    protected abstract void MoveTowardsPlayer();
    
    public virtual void HandleDamage(int damage)
    {
        int actualDamage = Mathf.Clamp(damage - _endurance, 0, damage);
        _health -= actualDamage;

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public int SpreadDamage()
    {
        return _damage;
    }

    private void OnDestroy()
    {
        gameManager.AddScore(_score);
    }
}
