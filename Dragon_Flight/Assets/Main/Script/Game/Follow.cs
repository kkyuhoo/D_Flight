using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public float maxShotDelay;
    public float curShotDelay;

    public GameObject bulletObjF;

    //public Vector3 followPos;
    //public int followDelay;
    //public Transform parent;
    //pullic Queue<Vector3>parentPos;

    void Update()
    {
        SubFollow();
        Fire();
        Reload();
    }
    void SubFollow()
    {
        //transform.position = followPos;
    }
    void Fire()
    {
        if (curShotDelay < maxShotDelay)
            return;

        Vector3 positionVector = new Vector3(transform.position.x, transform.position.y, -1);
        GameObject followBullet = Instantiate(bulletObjF, positionVector, transform.rotation);
        Rigidbody2D rigid_F = followBullet.GetComponent<Rigidbody2D>();
        rigid_F.AddForce(Vector2.up * 10, ForceMode2D.Impulse);

        curShotDelay = 0;
    }
    void Reload()
    {
        curShotDelay += Time.deltaTime;
    }
}
