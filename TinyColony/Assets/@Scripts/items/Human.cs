using System;
using System.Collections;
using UnityEngine;
public class Human : ItemBase
{
    public float scaleDownSpeed = 3f;
    public float moveSpeed = 1f;
    [NonSerialized]
    public Transform portal;
    public IEnumerator ArriveCoroutine()
    {
        while (transform?.localScale.x > 0)
        {
            transform.localScale -= Vector3.one * scaleDownSpeed * Time.deltaTime;

            Vector3 directionToPortal = (portal.position - transform.position).normalized;
            transform.position += directionToPortal * moveSpeed * Time.deltaTime;

            if (transform.localScale.x < 0)
                transform.localScale = Vector3.zero;

            yield return null;
        }
        Destroy(gameObject,1f);
    }
}
