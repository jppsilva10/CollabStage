using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiTouch2 : MonoBehaviour
{
    public float scale;
    private int index = -1;
    private Vector3 offset;
    private Collider2D c;
    private HingeJoint2D joint;
    private Rigidbody2D rb;

    private Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        c = GetComponent<Collider2D>();
        joint = GetComponent<HingeJoint2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        for(int i=0; i<Input.touchCount; i++)
        {
            
            Touch t = Input.GetTouch(i);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(t.position);
            touchPosition.z = 0;
            
            if (t.phase == TouchPhase.Began)
            {
                if (c.bounds.Contains(touchPosition))
                {
                    index = t.fingerId;
                    offset = transform.position - touchPosition;
                }
                    
            }
            else if (t.phase == TouchPhase.Moved && index == t.fingerId)
            {
                //position = touchPosition + offset;
                //Vector3 anchor = new Vector3(joint.anchor.x, joint.anchor.y, 0);

                //Vector3 initialDirection = transform.position - anchor;
                //Vector3 finalDirection = touchPosition + offset - anchor;

                //joint.jointAngle += Vector3.Angle(initialDirection, finalDirection);

                rb.velocity = touchPosition - transform.position;
                rb.velocity *= scale;
                //rb.velocity = Vector3.Normalize(rb.velocity) * scale;


            }
            else if (t.phase == TouchPhase.Ended && index == t.fingerId)
            {
                rb.velocity = new Vector3(0, 0, 0);
                index = -1;
            }

        }
    }
}
