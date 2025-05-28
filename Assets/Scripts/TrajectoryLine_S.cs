using System.Data;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TrajectoryLine_S : MonoBehaviour
{
    private LineRenderer line;
    [SerializeField]
    private float lineLength;
    private float draggingLine;
    private bool dragging = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 2;
        lineLength = 2;
        draggingLine = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
        GameObject draggable = GameObject.FindGameObjectWithTag("Draggable");
        if (gameObject != null)
        {
            line.enabled = true;
            Vector3 end = Input.mousePosition;
            end.z = Mathf.Abs(Camera.main.transform.position.z);
            end = Camera.main.ScreenToWorldPoint(end);
            Vector3 direction = (end - gameObject.transform.position).normalized;
            Vector3 endpoint = gameObject.transform.position + direction * lineLength;

            line.SetPosition(0, gameObject.transform.position);
            line.SetPosition(1, endpoint);
        }
        else if(draggable != null)
        {
            Vector3 start;
            Vector3 end = Vector3.zero;
            line.enabled = true;
            if(Input.GetMouseButtonDown(0))
            {
                end = GameObject.FindGameObjectWithTag("Draggable").transform.position;
                dragging = true;
            }
            else if(Input.GetMouseButtonUp(0))
            {
                draggingLine = 0.0f;
                dragging = false;
            }
            if(dragging)
            {
                draggingLine += Time.deltaTime;
                if (draggingLine > 2.0f)
                {
                    draggingLine = 2.0f;
                }

                start = GameObject.FindGameObjectWithTag("Draggable").transform.position;
                Vector3 direction = (end - start).normalized;
                Vector3 endpoint = draggable.transform.position + direction * draggingLine;

                line.SetPosition(0, draggable.transform.position);
                line.SetPosition(1, endpoint);
            }  
        }
        else
        {
            line.enabled = false;
            draggingLine = 0.0f;
        }
    }
}