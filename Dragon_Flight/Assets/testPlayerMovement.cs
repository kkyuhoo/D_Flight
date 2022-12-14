using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPlayerMovement : MonoBehaviour
{
    //방향키 입력을 받아서 이동시키는 코드
    public float speed = 5f;
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector3.right * h * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * v * speed * Time.deltaTime);
    }    
}