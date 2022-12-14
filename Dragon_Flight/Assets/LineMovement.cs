using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMovement : MonoBehaviour
{
	GameObject target;
	public GameObject meteor;

	public float speed = 0f;
	private float timer = 0f;

    void Start()
    {
		//플레이어의 위치를 target에 저장
		target = GameObject.Find("Player");
    }

    void Update()
	{
		//플레이어의 x축으로 이동
		transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x, transform.position.y, transform.position.z), speed * Time.deltaTime);

		//3초 뒤 new Vector3(transform.position.x, 6, 0)에 meteor 생성
		timer += Time.deltaTime;
		if (timer >= 3f)
		{
			Instantiate(meteor, new Vector3(transform.position.x, 6, 0), Quaternion.identity);
			timer = 0f;			
			Destroy(gameObject);
		}
	}
}