using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossMovement : MonoBehaviour
{
    
    Rigidbody2D rb;
    public float speed = 10f;

    public float startHealth;
    public float health;

    public GameObject healthBar;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // ?„ëž˜ë¡?ê°€?¤ê? yì¶•ì´ 2.5ë³´ë‹¤ ?‘ì•„ì§€ë©?ë©ˆì¶˜??
        if (transform.position.y > 2f)
        {
            rb.velocity = new Vector2(0, -speed * Time.deltaTime);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "PlayerBullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            OnHit(bullet.dmg);

            Destroy(collision.gameObject);
        }

    }

    void OnHit(int dmg)
    {
        if (health <= 0)
            return;

        health -= dmg;
        healthBar.GetComponent<Image>().fillAmount = health / startHealth;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
