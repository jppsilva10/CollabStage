using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteCharacter : MonoBehaviour
{
    private GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
    }


    void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("auau");
        GameObject collisionObject = collision.gameObject;
        MultiTouch mt = null;
        try {
            mt = obj.GetComponent<MultiTouch>();
        }
        catch (UnityException e)
        {
            return;
        }

        if (mt.index != -1)
        {
            obj = collisionObject;
        }

    }

}
