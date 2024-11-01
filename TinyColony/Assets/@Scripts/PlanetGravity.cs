
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour
{
    public float gravityScale = 3f;
    public float dragCoefficient = 0.05f;    // 저항 계수

    List<Rigidbody2D> items = new List<Rigidbody2D>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ItemBase>() != null)
        {
            items.Add(collision.GetComponent<Rigidbody2D>());
            collision.GetComponent<ItemBase>().isAtmosphere = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<ItemBase>() != null)
        {
            items.Remove(collision.GetComponent<Rigidbody2D>());
        }
    }
    private void FixedUpdate()
    {
        for(int i = 0; i < items.Count; i++)
        {
            Vector3 dir = transform.position - items[i].transform.position;
            items[i].AddForce(dir.normalized * gravityScale);

            Vector3 velocity = items[i].linearVelocity;
            Vector3 dragForce = -dragCoefficient * velocity.magnitude * velocity;
            items[i].AddForce(dragForce);
        }
    }

    
}
