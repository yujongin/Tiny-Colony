using UnityEngine;

public class ItemBase : MonoBehaviour
{
    public bool isAtmosphere;

    //landing planet
    void Update()
    {
        if (isAtmosphere)
        {
            if(GetComponent<Rigidbody2D>().linearVelocity != Vector2.zero)
            {
                Rigidbody2D rb = GetComponent<Rigidbody2D>();   
                float angle = Mathf.Atan2(rb.linearVelocity.y, rb.linearVelocity.x) * Mathf.Rad2Deg;

                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isAtmosphere = false;
    }
}
