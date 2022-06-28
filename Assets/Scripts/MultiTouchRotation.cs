using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiTouchRotation : MultiTouch
{

    protected float rotationOffset;

    override
    protected void TransformationStart(Vector3 touchPosition)
    {
        //base.TransformationStart(touchPosition);
        offset = touchPosition - transform.position;
        offset.Normalize();

        rotationOffset = Vector3.SignedAngle(transform.parent.up, transform.up, Vector3.forward);
    }

    override
    protected void Transformation(Vector3 touchPosition)
    {
        Vector3 target = touchPosition - transform.position;
        target.z = transform.position.z;
        target.Normalize();

        float angle = Vector3.SignedAngle(offset, target, Vector3.forward) + rotationOffset;

        transform.up = Quaternion.Euler(0, 0, angle) * transform.parent.up;
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
