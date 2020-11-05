using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    public float speed;
    public float lineOfSite;
    public float shootingRange;
    private Transform player;
    private Rigidbody2D rb;

    public Transform attackPoint;
    public float attackRange = 0.5f;

    public int attackDamage = 10;
    public LayerMask playerLayer;

    public float delayTime = 0f;
    public float delayTime1 = 1.1f;
    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if(distanceFromPlayer < lineOfSite && distanceFromPlayer >shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
        else if (distanceFromPlayer <= shootingRange)
        {
            Attack();
            delayTime1 = delayTime1 + 1.1f;
        }
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    }
    public void Attack()
    {
        if (Time.time >= delayTime)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
            foreach (Collider2D player in hitEnemies)
            {
                player.GetComponent<PlayerHP>().TakeDamage(attackDamage);
            }
            delayTime = Time.time + 2f;
        }
        
    }
}

