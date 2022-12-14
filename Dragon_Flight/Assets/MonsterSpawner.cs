using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject Meteor;
    public GameObject Target;
    public List<GameObject> mob = new List<GameObject>();
    public GameObject Boss;
    public Text Text;

    float time = 0f;
    float lasttime = 0f;
    float time2 = 0f;
    float lasttime2 = 0f;
    float time120 = 120f;
    bool boss = false;


    void Start()
    {
        
    }

   void Update()
    {
        time += Time.deltaTime;
        time2 += Time.deltaTime;

        if(time >= lasttime + 3)
        {
            if(boss == false)
            {
            Monster1Spawn();
            lasttime = time;
            }
        }

        if(time >= time120)
        {
            //UI 텍스트 5초간 활성화 이후 비활성화
            Text.gameObject.SetActive(true);
            Invoke("TextOff", 6.0f);


            BossSpawn();
            boss = true;
            time120 = 9999f;
        }

        // 10초 마다 50% 확률로 Target.transform.position, transform.rotation에 Meteor 생성
        if (time2 >= lasttime2 + 6)
        {
            Debug.Log("메테오 호출");
            switch (Random.Range(0, 2))
            {
                case 0:
                Instantiate(Meteor, Target.transform.position, transform.rotation);
                Debug.Log("성공");
                break;

                case 1:
                Debug.Log("생성X");
                break;
            }
            lasttime2 = time2;
        }
    }

    void TextOff()
    {
        //Text 애니메이션 실행
        Text.gameObject.SetActive(false);
    }

    void BossSpawn()
    {
        Instantiate(Boss, new Vector3(0, 7.5f, 0), transform.rotation);
    }

    void Monster1Spawn()
    {
        switch(Random.Range(0, 2))
        {
            case 0: Instantiate(mob[Random.Range(0, 4)], new Vector3(-2.0f, 6, 0), transform.rotation); break;
            case 1: break;
        }
        switch (Random.Range(0, 2))
        {
            case 0: Instantiate(mob[Random.Range(0, 4)], new Vector3(-0.7f, 6, 0), transform.rotation); break;
            case 1: break;
        }
        switch (Random.Range(0, 2))
        {
            case 0: Instantiate(mob[Random.Range(0, 4)], new Vector3(0.7f, 6, 0), transform.rotation); break;
            case 1: break;
        }
        switch (Random.Range(0, 2))
        {
            case 0: Instantiate(mob[Random.Range(0, 4)], new Vector3(2.0f, 6, 0), transform.rotation); break;
            case 1: break;
        }
    }
}