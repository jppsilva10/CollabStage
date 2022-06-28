using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiTouch : MonoBehaviour
{
    public bool registTouch = true;
    public bool velocityBased;
    public bool havePhisics=true;
    public float scale;
    public int index = -1;
    protected Vector3 offset;
    protected Collider2D c;
    protected Rigidbody2D rb;

    protected bool[] touches;

    // Start is called before the first frame update
    void Start()
    {
        c = GetComponent<Collider2D>();
        if (havePhisics)
        {
            rb = GetComponent<Rigidbody2D>();
        }
        touches = Camera.main.GetComponent<SharedData>().touches;
    }

    virtual
    protected void ManageTouch(Touch t)
    {

    }

    virtual
    protected void TransformationStart(Vector3 touchPosition)
    {
        offset = transform.position - touchPosition;
    }

    virtual
    protected void Transformation(Vector3 touchPosition)
    {
        if (havePhisics)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
        transform.position = touchPosition + offset;
    }

    virtual
    protected void TransformationEnd(Vector3 touchPosition)
    {
        if (velocityBased)
        {
            rb.velocity = touchPosition - transform.position;
            rb.velocity *= scale;
        }
        index = -1;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<Input.touchCount; i++)
        {
            
            Touch t = Input.GetTouch(i);

            //Debug.Log(t.pressure);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(t.position);
            touchPosition.z = transform.position.z;
            
            if (t.phase == TouchPhase.Began)
            {
                if (c.bounds.Contains(touchPosition) && !Camera.main.GetComponent<SharedData>().touches[t.fingerId])
                {
                    index = t.fingerId;
                    if (registTouch) Camera.main.GetComponent<SharedData>().touches[t.fingerId] = true;
                    TransformationStart(touchPosition);
                }
                    
            }
            else if (t.phase == TouchPhase.Moved && index == t.fingerId)
            {
                Transformation(touchPosition);
            }
            else if (t.phase == TouchPhase.Ended && index == t.fingerId)
            {
                if(registTouch) Camera.main.GetComponent<SharedData>().touches[t.fingerId] = false;
                TransformationEnd(touchPosition);
            }


        }
    }

    private void LateUpdate()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {

            Touch t = Input.GetTouch(i);
            ManageTouch(t);

        }
    }
}
