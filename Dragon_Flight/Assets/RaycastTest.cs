using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{
    [SerializeField]
    private LineRendererAtoB visualizerLine;
    [SerializeField]
    private Transform owner;

    // Update is called once per frame
    void Update()
    {
        Vector2 target = Vector2.zero;
        target.x = Input.mousePosition.x - Screen.width * 0.5f;
        target.y = Input.mousePosition.y - Screen.height * 0.5f;

        Vector2 direction = (target - (Vector2)owner.position).normalized;

        RaycastHit2D hit = Physics2D.Raycast(owner.position, direction, Mathf.Infinity);

        if ( hit )
        {
            visualizerLine.Play(owner.position, hit.point);
        }
        else
        {
            visualizerLine.Stop();
        }
    }
}
