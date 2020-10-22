using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack2 : MonoBehaviour
{
    [SerializeField]
    private int playerIndex = 0;

    private int attackDamage = 25;
    private int skillDamage = 75;

    //public Transform skillPoint;
    public GameObject bulletPrefab;
    public GameObject skillPoint;
    public float skillRange = 2f;

    public Transform attackPoint;
    public float attackRange = 0.5f;

    private float nextAttackTime = 0f;
    private float nextSkillTime = 0f;
    private float delayTime = 0f;

    public LayerMask enemyLayer;


    public int GetPlayerIndex()
    {
        return playerIndex;
    }


    public void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    public void SetInputAttack(bool Attack)
    {
        if (Time.time >= nextAttackTime && Time.time >= delayTime)
        {
            if (Attack == true)
            {
                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
                foreach (Collider2D enemy in hitEnemies)
                {
                    enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
                }
                nextAttackTime = Time.time + 1f;
                delayTime = Time.time + 0.5f;
            }
        }
    }
    public void SetInputSkill(bool Attack)
    {
        if (Time.time >= nextSkillTime && Time.time >= delayTime)
        {
            if (Attack == true)
            {
                nextAttackTime = Time.time + 1f;
                delayTime = Time.time + 0.5f;
            }
        }
    }
}
