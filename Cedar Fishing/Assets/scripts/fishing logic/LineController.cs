using UnityEngine;

public class LineController : MonoBehaviour
{

    private LineRenderer lineRenderer;

    public Transform bobber;
    public Transform rod;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, bobber.position);
        lineRenderer.SetPosition(1, rod.position);
    }
}
