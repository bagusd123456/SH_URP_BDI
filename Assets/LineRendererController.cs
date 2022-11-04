using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererController : MonoBehaviour
{
    public static LineRendererController Instance { get; private set; }
    public LineRenderer lineRenderer;
    Vector3[] linePoints = new Vector3[2];

    public Camera cam;
    public bool canShoot;

    private void Awake()
    {
        Instance = this;
        linePoints[0] = lineRenderer.GetPosition(0);
    }
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && canShoot)
        {
            StartCoroutine(ActivateLineRenderer());
            canShoot = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            canShoot = true;
        }

            
    }

    public IEnumerator ActivateLineRenderer()
    {
        if (lineRenderer.enabled == false) lineRenderer.enabled = true;
        Camera c = cam;
        Vector3 p = c.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, c.nearClipPlane));
        linePoints[1] = p;
        lineRenderer.SetPosition(1, new Vector3(p.x, p.y, p.z));

        yield return new WaitForSeconds(0.1f);
        lineRenderer.enabled = false;
    }
}
