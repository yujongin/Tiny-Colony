using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Launcher : MonoBehaviour
{
    public GameObject bucket;
    public List<Transform> linePoints;
    public float speed = 3;
    public List<GameObject> items;

    LineRenderer handleLineRenderer;
    Vector3 shootDir;

    bool isShoot = false;

    private void Awake()
    {
        Managers.Object.launcher = this;
    }
    void Start()
    {
        handleLineRenderer = GetComponent<LineRenderer>();
        handleLineRenderer.positionCount = 3;
        handleLineRenderer.startWidth = 0.01f;
        handleLineRenderer.endWidth = 0.01f;
    }

    Vector2 startPoint;
    void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            }

            if (Input.GetMouseButton(0))
            {
                Vector2 currentPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Vector2 dir = startPoint - currentPoint;
                dir = Vector2.ClampMagnitude(dir, 3f);

                bucket.transform.position = transform.position - new Vector3(dir.x, dir.y, 0);


                shootDir = transform.position - bucket.transform.position;
                DrawLine();

            }

            if (Input.GetMouseButtonUp(0))
            {
                isShoot = true;
                bucket.transform.localPosition = Vector3.zero;
                DrawLine();

            }
        }
    }
    void FixedUpdate()
    {
        if (isShoot)
        {
            ShootItem(shootDir);
            isShoot = false;
        }
    }

    void DrawLine()
    {
        handleLineRenderer.SetPosition(0, linePoints[0].position);
        handleLineRenderer.SetPosition(1, bucket.transform.position);
        handleLineRenderer.SetPosition(2, linePoints[1].position);
    }

    public void AddItem(GameObject obj)
    {
        items.Add(obj);
        obj.transform.parent = bucket.transform;
        obj.transform.localPosition = Vector3.zero;
        obj.GetComponent<Collider2D>().enabled = false;
    }

    public void RemoveItem(GameObject obj)
    {
        if (items.Contains(obj))
        {
            items.Remove(obj);
        }
    }

    void ShootItem(Vector3 shootDir)
    {
        for (int i = 0; i < items.Count; i++)
        {
            items[i].GetComponent<Rigidbody2D>().AddForce(shootDir * speed, ForceMode2D.Impulse);
            items[i].transform.parent = Managers.Object.GetRoot(items[i]);
            items[i].GetComponent<Collider2D>().enabled = true;
        }
        items.Clear();
    }
}
