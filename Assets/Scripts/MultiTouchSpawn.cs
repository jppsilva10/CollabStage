using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiTouchSpawn : MultiTouch
{

    public GameObject obj;

    public GameObject popup;

    //private GameObject[] objList = new GameObject[40];

    private GameObject objRef = null;

    public Vector3 tpos = new Vector3(0,0,0);
    public float time = 0;

    public float timeScale = 0.5f;

    override
    protected void ManageTouch(Touch t)
    {
        if(t.phase == TouchPhase.Began)
        {
            if (!touches[t.fingerId])
            {


                Debug.Log(Time.fixedTime);
                Vector3 touchPos = Camera.main.ScreenToWorldPoint(t.position);
                Vector3 dif = touchPos - tpos;
                float timeDiff = Time.time - time;

                if (tpos.magnitude != 0 && (dif.magnitude>-10 && dif.magnitude < 10) && timeDiff < timeScale)
                {

                    RectTransform objectRectTransform = gameObject.GetComponent<RectTransform>();

                    Vector2 pos = t.position;
                    float rot = 0;

                    if (pos.y < objectRectTransform.rect.height / 10)
                    {
                        pos.y = 0;
                    }
                    else if (pos.y > 9 * objectRectTransform.rect.height / 10)
                    {
                        pos.y = objectRectTransform.rect.height;
                        rot = 180;
                    }
                    else if (pos.x < objectRectTransform.rect.width/15)
                    {
                        pos.x = 0;
                        rot = -90;
                    }

                    else if (pos.x > 14 * objectRectTransform.rect.width / 15)
                    {
                        pos.x = objectRectTransform.rect.width;
                        rot = 90;
                    }
                    else
                    {
                        return;
                    }

                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(pos);
                    touchPosition.z = 0;

                    //if (objRef != null) Destroy(objRef);

                    popup.SetActive(false);

                    if (objRef == null)
                    {
                        objRef = Instantiate(obj, touchPosition, Quaternion.identity);
                        objRef.transform.Rotate(0, 0, rot);
                    }
                    else
                    {

                        objRef.transform.position = touchPosition;
                        objRef.transform.up = Vector3.up;
                        objRef.transform.Rotate(0, 0, rot);
                        objRef.SetActive(true);
                    }

                    Debug.Log(t.position);
                    tpos = new Vector3(0, 0, 0);
                }
                else
                {
                    time = Time.time;
                    tpos = touchPos;
                }
            }
        }
        /*
        if (t.phase == TouchPhase.Ended)
        {
            if (objList[t.fingerId]!=null)
            {
                Destroy(objList[t.fingerId]);
                objList[t.fingerId] = null;
            }
        }
        */
    }

    override
    protected void TransformationStart(Vector3 touchPosition)
    {
    }

    override
    protected void Transformation(Vector3 touchPosition)
    {
    }

    override
    protected void TransformationEnd(Vector3 touchPosition)
    {
    }
}
