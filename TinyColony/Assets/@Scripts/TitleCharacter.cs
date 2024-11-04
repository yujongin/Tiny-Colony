using UnityEngine;
using UnityEngine.UIElements;

public class TitleCharacter : MonoBehaviour
{
    public float rotationSpeed = 25f;

    public float moveSpeed = 1f;

    public Vector3 originalPos;
    void Start()
    {
        originalPos = transform.position;
    }

    void Update()
    {
        Vector3 moveDirection = new Vector3(1, 0.2f, 0).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime,Space.World);

        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

        if (transform.position.x > 15)
        {
            transform.position = originalPos;
        }
    }
}
