using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class EnemyEntity : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    private int _currentHealth;


    private void Start()
    {
        _currentHealth = _maxHealth;
    }



    public void TakeDamadge(int damadge)
    {
        _currentHealth -= damadge;


        DetectDeath();

    }

    private void DetectDeath()
    {
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
