using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public GameObject bullet;
    public float oneShoting = 10f;

    Rigidbody2D rb;
    public float speed = 10f;
    public float bulletSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(SpellStart());
    }

    // Update is called once per frame
    void Update()
    {
        // 아래로 가다가 y축이 2.5보다 작아지면 멈춘다.
        if (transform.position.y > 2f)
        {
            rb.velocity = new Vector2(0, -speed * Time.deltaTime);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    IEnumerator SpellStart()
    {
        float angle = 360 / oneShoting;

        do
        {
            for (int i = 0; i < oneShoting; i++)
            {
                Debug.Log(i);
                GameObject obj;
                obj = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);

                //보스의 위치에 bullet을 생성합니다.
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletSpeed * Mathf.Cos(Mathf.PI * 2 * i / oneShoting), bulletSpeed * Mathf.Sin(Mathf.PI * 2 * i / oneShoting)));

                obj.transform.Rotate(new Vector3(0f, 0f, 360 * i / oneShoting - 90));
            }
            //지정해둔 각도의 방향으로 모든 총탄을 날리고, 날아가는 방향으로 방향회전을 해줍니다.
            yield return new WaitForSeconds(1f);

        } while (true);
    }
}