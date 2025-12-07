using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
public class Sword : MonoBehaviour
{

    [SerializeField] private int _damadgeAmount = 2;

    public event EventHandler OnSwordSwing;

    private PolygonCollider2D _polygonCollider2D;
    private void Awake()
    {
        _polygonCollider2D = GetComponent<PolygonCollider2D>();
    }

    private void Start()
    {
        AttackColliderTurnOff();
    }

    public void Attack()
    {
        AttackColliderTurnOffOn();

        OnSwordSwing?.Invoke(this, EventArgs.Empty);
    }

    public void AttackColliderTurnOff()
    {
        _polygonCollider2D.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out EnemyEntity enemyEntity))
        {

            enemyEntity.TakeDamadge(_damadgeAmount);
        }
    }

    private void AttackColliderTurnOn()
    {
        _polygonCollider2D.enabled = true;

    }

    private void AttackColliderTurnOffOn()
    {
        AttackColliderTurnOff();
        AttackColliderTurnOn();
        
    }
}
