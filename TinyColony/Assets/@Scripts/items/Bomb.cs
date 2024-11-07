using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bomb : ItemBase
{
    public GameObject maskPrefab;
    public Collider2D triggerCollider;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var contacts = new ContactPoint2D[collision.contactCount];
        if (collision.contactCount > 0)
        {
            collision.GetContacts(contacts);
        }

        Explode(contacts[0].point);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Human"))
        {
            //sound?
            Managers.Object.DespawnItem(collision.gameObject);
        }
        else if (collision.CompareTag("Env"))
        {
            Managers.Object.DespawnItem(collision.gameObject);
        }
        else if (collision.CompareTag("Nuclear")) 
        {
            collision.GetComponent<NuclearPowerStation>().Explode(collision.transform.position);
        }
    }
    public void DestoryBomb()
    {
        triggerCollider.enabled = false;
        Managers.Object.DespawnItem(gameObject);
    }
    public void Explode(Vector2 pos)
    {
        GetComponent<Animator>().SetTrigger("Explode");
        Managers.Sound.PlayOneShot(Managers.Sound.explodeSound);
        triggerCollider.enabled = true;
        GameObject[] planets = GameObject.FindGameObjectsWithTag("Planet");

        GameObject closestPlanet = null;
        float closestDistanceSqr = Mathf.Infinity;

        Vector3 currentPosition = transform.position;

        foreach (GameObject target in planets)
        {
            Vector3 directionToTarget = target.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;

            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                closestPlanet = target;
            }
        }
        GameObject mask = GameObject.Instantiate(maskPrefab, closestPlanet.transform);
        mask.transform.position = pos;
        GetComponent<Collider2D>().enabled = false;
    }
}
