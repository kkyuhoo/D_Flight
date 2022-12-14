using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterMovement : MonoBehaviour
{
    Rigidbody2D rigid;
    public float speed;

    public float startHealth;
    public float health;

    public GameObject healthBar;
    public GameObject itemCoin;
    public GameObject itemPower;
    public GameObject itemSpecialMove;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.down * speed;
    }

    void Update()
    {
        rigid.velocity = Vector2.down * Time.deltaTime * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BorderBullet")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "PlayerBullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            OnHit(bullet.dmg);

            Destroy(collision.gameObject);
        }

    }
    void OnHit(int dmg)
    {
        if(health <= 0)
            return;

        health -= dmg;
        healthBar.GetComponent<Image>().fillAmount = health / startHealth;

        if (health <= 0)
        {

            // #.Random Radio Item Drop
            float ran = Random.Range(0, 10);
            if(ran < 6)
            {
                Debug.Log("Not Item");
            }
            else if(ran < 8.8) // Coin 38%
            {
                Instantiate(itemCoin, transform.position, transform.rotation);
            }
            else if(ran < 9.8) // Power 10%
            {
                Instantiate(itemPower, transform.position, transform.rotation);
            }
            else if(ran < 10) // SpecialMove 2%
            {
                Instantiate(itemSpecialMove, transform.position, transform.rotation);
            }

            Destroy(gameObject);
        }
    }
    //void Die()
    //{
    //    Destroy(gameObject);
    //}

}
