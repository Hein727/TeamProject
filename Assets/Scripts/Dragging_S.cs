using Unity.Hierarchy;
using Unity.VisualScripting;
using UnityEngine;

public class Dragging_S : MonoBehaviour
{
    private Vector3 start;
    private Vector3 end;
    private float force = 10.0f;
    private Transform drag;
    private Rigidbody2D dragrigibody;
    private Vector3 offset;

    private void Update()
    {
        GameObject draggable = GameObject.FindGameObjectWithTag("Draggable");

        if(draggable != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                int LayerMask = 1 << draggable.layer;
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0f, LayerMask);
                if (hit)
                {
                    drag = hit.transform;
                    dragrigibody = drag.GetComponent<Rigidbody2D>();
                    if (dragrigibody != null)
                    {
                        dragrigibody.bodyType = RigidbodyType2D.Kinematic;
                        dragrigibody.linearVelocity = Vector2.zero;
                    }
                    offset = drag.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    end = drag.position;
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                if (dragrigibody != null)
                {
                    start = drag.position;
                    dragrigibody.bodyType = RigidbodyType2D.Dynamic;
                    Vector2 throwDir = (end - start).normalized;
                    float throwForce = throwDir.magnitude * force;

                    dragrigibody.AddForce(throwDir * throwForce, ForceMode2D.Impulse);
                }
                drag = null;
                dragrigibody = null;
            }

            if (drag != null)
            {
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mouseWorldPos.z += 10;

                float maxDrag = 2.0f;
                Vector3 origin = end;
                Vector3 clampPos = origin + Vector3.ClampMagnitude(mouseWorldPos - origin, maxDrag);
                drag.position = clampPos;
            }
        }
    }
}
