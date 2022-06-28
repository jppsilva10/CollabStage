using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKTarget : MonoBehaviour
{
    public GameObject parentObj;
    private MultiTouch mt;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = parentObj.transform.position;
        mt = GetComponent<MultiTouch>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = parentObj.transform.parent.rotation;
        if (mt.index < 0)
        {
            transform.position = parentObj.transform.position;
        }
    }
}
