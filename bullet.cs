using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 20;
    public Rigidbody2D rb;
    //public GameObject impactEffect;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.right);
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);

    }
    void OnBecameInvisible()
    {
        enabled = false;
        Destroy(gameObject);
    }
}
