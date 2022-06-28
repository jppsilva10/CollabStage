using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHead : MultiTouch
{
    private Quaternion rotationOffset;

    override
    protected void TransformationStart(Vector3 touchPosition)
    {
        //rotationOffset = transform.rotation;
        offset = touchPosition;
    }

    override
    protected void Transformation(Vector3 touchPosition)
    {

        Vector3 rotation = offset - touchPosition;
        rotation *= scale;

        Debug.Log(rotation);

        transform.up = Vector3.up;
        transform.Rotate(0,180,0);
        //transform.rotation = rotationOffset;
        transform.Rotate(rotation.y, rotation.x, 0);
    }

    override
    protected void TransformationEnd(Vector3 touchPosition)
    {
        if (velocityBased)
        {
        }
        index = -1;
    }
}
