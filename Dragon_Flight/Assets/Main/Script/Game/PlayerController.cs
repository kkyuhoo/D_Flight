using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private bool isTouchTop;
    private bool isTouchBottom;
    private bool isTouchLeft;
    private bool isTouchRight;

    public float speed;
    public int power;
    public int maxPower;
    public float playerHp = 3f;
    public static float score = 0f;

    public int specialMove;
    public int maxSpecialMove;

    public float maxShotDelay;
    public float curShotDelay;
    public float curSpecialMoveDelay;
    public float maxSpecialMoveDelay;

    public GameObject bulletSpecialMove;
    public GameObject bulletObjA;
    public GameObject bulletObjB;
    public GameObject bulletObjC;
    public GameObject bulletObjD;

    public List<GameObject> hpList = new List<GameObject>();
    //ui pannel
    public GameObject uiPannel;
    public GameObject mainCamera;
    public GameObject scoreUI;

    private bool isSpecialMoveTime = false;
    public bool isFire;

    // Manager
    public GameManager gameManager;
    public ObjectManager objectManager;

    Animator anim;

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
        BulletSpecialMove();
        Reload();
    }

    private void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            --playerHp;
            Debug.Log("Player Hp : " + playerHp);
            //mainCamera 셋트리거
            mainCamera.GetComponent<Animator>().SetTrigger("CameraShake");

            switch (playerHp)
            {
                case 0:
                    hpList[0].SetActive(false);
                    hpList[1].SetActive(false);
                    hpList[2].SetActive(false);
                    uiPannel.SetActive(true);
                    Time.timeScale = 0;
                    break;
                case 1:
                    hpList[0].SetActive(true);
                    hpList[1].SetActive(false);
                    hpList[2].SetActive(false);
                    break;
                case 2:
                    hpList[0].SetActive(true);
                    hpList[1].SetActive(true);
                    hpList[2].SetActive(false);
                    break;
                case 3:
                    hpList[0].SetActive(true);
                    hpList[1].SetActive(true);
                    hpList[2].SetActive(true);
                    break;
            }
        }

        // 플레이어 범위 제한 설정
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = true;
                    break;
                case "Bottom":
                    isTouchBottom = true;
                    break;
                case "Left":
                    isTouchLeft = true;
                    break;
                case "Right":
                    isTouchRight = true;
                    break;
            }
        }

        // 아이템 충돌 처리
        if (collision.gameObject.tag == "Item")
        {
            Item item = collision.gameObject.GetComponent<Item>();
            switch (item.type)
            {
                case "Coin":
                    score += 1000;
                    //scoreUI에 score 출력
                    scoreUI.GetComponent<Text>().text = score.ToString();
                    break;
                case "Power":
                    if (power == maxPower)
                    {
                        //scroe += 500;
                    }
                    else
                    {
                        power++;
                    }
                    break;

                case "Invincible":
                    // 무적 효과
                    break;

                case "Specialmove":
                    // 필살기
                    if (specialMove == maxSpecialMove)
                    {
                        Debug.Log("필살기 더이상 축적 불가능");
                    }
                    //scroe += 500;
                    else
                    {
                        specialMove++;
                    }
                    //test
                    break;

            }
            Destroy(collision.gameObject);
        }

    }
    void OnTriggerExit2D(Collider2D collision)
    {
        // 플레이어 범위 제한 설정
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = false;
                    break;
                case "Bottom":
                    isTouchBottom = false;
                    break;
                case "Left":
                    isTouchLeft = false;
                    break;
                case "Right":
                    isTouchRight = false;
                    break;
            }
        }
    }

    void Move()
    {
        // 플레이어 이동
        float h = Input.GetAxisRaw("Horizontal");
        if ((isTouchRight && h == 1) || (isTouchLeft && h == -1))
        {
            h = 0;
        }
        float v = Input.GetAxisRaw("Vertical");
        if ((isTouchTop && v == -1) || (isTouchBottom && v == 1))
        {
            v = 0;
        }
        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(h, v, 0) * speed * Time.deltaTime;
        transform.position = curPos + nextPos;
    }

    void Fire()
    {
        if (curShotDelay < maxShotDelay)
            return;

        if (!isFire)
            return;

        switch (power)
        {
            case 1:
                Vector3 positionVector_A = new Vector3(transform.position.x, transform.position.y, -1);
                GameObject bullet_A = Instantiate(bulletObjA, positionVector_A, transform.rotation);
                Rigidbody2D rigid_A = bullet_A.GetComponent<Rigidbody2D>();
                rigid_A.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                break;
            case 2:
                Vector3 positionVector_B = new Vector3(transform.position.x, transform.position.y, -1);
                GameObject bullet_B = Instantiate(bulletObjB, positionVector_B, transform.rotation);
                Rigidbody2D rigid_B = bullet_B.GetComponent<Rigidbody2D>();
                rigid_B.AddForce(Vector2.up * 10, ForceMode2D.Impulse);

                break;
            case 3:
                Vector3 positionVector_C = new Vector3(transform.position.x, transform.position.y, -1);
                GameObject bullet_C = Instantiate(bulletObjC, positionVector_C, transform.rotation);
                Rigidbody2D rigid_C = bullet_C.GetComponent<Rigidbody2D>();
                rigid_C.AddForce(Vector2.up * 10, ForceMode2D.Impulse);

                // Follower 오브젝트 활설화
                GameObject.Find("Player").transform.Find("Follewer_01").gameObject.SetActive(true);

                break;
            case 4:
                Vector3 positionVector_D = new Vector3(transform.position.x, transform.position.y, -1);
                GameObject bullet_D = Instantiate(bulletObjD, positionVector_D, transform.rotation);
                Rigidbody2D rigid_D = bullet_D.GetComponent<Rigidbody2D>();
                rigid_D.AddForce(Vector2.up * 10, ForceMode2D.Impulse);

                // Follower 오브젝트 활설화
                GameObject.Find("Player").transform.Find("Follewer_02").gameObject.SetActive(true);

                break;
        }
        curShotDelay = 0;

    }

    void Reload()
    {
        curShotDelay += Time.deltaTime;
    }

    void OffBulletSpecialMove()
    {
        bulletSpecialMove.SetActive(false);
    }
    void BulletSpecialMove()
    {

        //// Remove Enemy
        //GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //for (int index = 0; index < enemies.Length; index++)
        //{
        //    Enemy enemyLogic = enemies[index].GetComponent<Enemy>();
        //    enemyLogic.OnHit(1000);
        //}

        //// Remove Enemy Bullet
        //GameObject[] bullets = GameObject.FindGameObjectsWithTag("EnemyBullet");
        //for (int index = 0; index < bullets.Length; index++)
        //{
        //    Destroy(bullets[index]);
        //}

        if (!Input.GetButton("Jump"))
            return;

        if (specialMove == 0)
            return;

        if (isSpecialMoveTime == false)
        {
            StopFire();
            isSpecialMoveTime = true;
            InvokeRepeating("bulletInvoke", 0, 0.125f);
            StartCoroutine(PlayMove());
            specialMove--;
        }
        else
        {
            Debug.Log("아직 필살기를 사용할 수 없습니다. ");
        }
    }

    void bulletInvoke()
    {
        Vector3 specialVector = new Vector3(transform.position.x, transform.position.y, -1);
        GameObject Special = Instantiate(bulletSpecialMove, specialVector, transform.rotation);
        Rigidbody2D specialMoveRigid = Special.GetComponent<Rigidbody2D>();
        specialMoveRigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
    }

    IEnumerator PlayMove()
    {
        yield return new WaitForSeconds(3.0f);
        CancelInvoke("bulletInvoke");
        isSpecialMoveTime = false;
        isFire = true;
    }
    void StopFire()
    {
        isFire = false;
    }
}
