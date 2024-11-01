using System.Net.Sockets;
using UnityEngine;

public class TraceLine : MonoBehaviour
{

    LineRenderer lineRenderer;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.04f;
        lineRenderer.endWidth = 0.02f;
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            lineRenderer.enabled = true;

            DrawTrace();
        }
        if (Input.GetMouseButtonUp(0))
        {
            lineRenderer.enabled = false;
        }
    }

    float offsetX = 0;
    float tilingScale = 5;
    void DrawTrace()
    {
        Vector3 dir = transform.parent.position - transform.position;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.parent.position + dir);
        Vector2 tiling = new Vector2(dir.magnitude, 1);
        lineRenderer.material.mainTextureScale =  tiling * tilingScale;
        Vector2 offset = new Vector2(offsetX, 0);
        offsetX -= Time.deltaTime;
        lineRenderer.material.mainTextureOffset = offset;
    }
}
