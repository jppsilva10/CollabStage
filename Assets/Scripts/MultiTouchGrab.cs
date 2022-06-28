using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiTouchGrab : MultiTouch
{
    public bool insideTrash;

    override
    protected void Transformation(Vector3 touchPosition)
    {
        if (havePhisics)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
        transform.position = touchPosition + offset;
    }

    override
    protected void TransformationEnd(Vector3 touchPosition)
    {
        if (velocityBased)
        {
            rb.velocity = touchPosition - transform.position;
            rb.velocity *= scale;
        }
        index = -1;

        if (insideTrash)
        {
            Destroy(gameObject);
            GameObject obj = GameObject.FindGameObjectsWithTag("Trash")[0];
            obj.transform.GetChild(0).gameObject.SetActive(false);
            obj.transform.localScale = new Vector3(1, 1, 1);


            GameObject[] list = GameObject.FindGameObjectsWithTag("Menu");
            for (int i = 0; i < list.Length; i++)
            {
                list[i].GetComponent<SpriteRenderer>().enabled = true;
            }

            list = GameObject.FindGameObjectsWithTag("MenuWindow");
            for (int i = 0; i < list.Length; i++)
            {
                list[i].GetComponent<Canvas>().enabled = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.CompareTag("Trash"))
        {
            if(index != -1)
            {
                insideTrash = true;
                obj.transform.GetChild(0).gameObject.SetActive(true);
                obj.transform.localScale = new Vector3(2, 2, 1);
                GameObject[] list = GameObject.FindGameObjectsWithTag("Menu");
                for (int i = 0; i < list.Length; i++)
                {
                    list[i].GetComponent<SpriteRenderer>().enabled = false;
                }

                list = GameObject.FindGameObjectsWithTag("MenuWindow");
                for (int i = 0; i < list.Length; i++)
                {
                    list[i].GetComponent<Canvas>().enabled = false;
                }
            }
        }
        Debug.Log(obj.tag);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!insideTrash)
        {
            GameObject obj = collision.gameObject;
            if (obj.CompareTag("Trash"))
            {
                if (index != -1)
                {
                    insideTrash = true;
                    obj.transform.GetChild(0).gameObject.SetActive(true);
                    obj.transform.localScale = new Vector3(2, 2, 1);
                    GameObject[] list = GameObject.FindGameObjectsWithTag("Menu");
                    for (int i = 0; i < list.Length; i++)
                    {
                        list[i].GetComponent<SpriteRenderer>().enabled = false;
                    }

                    list = GameObject.FindGameObjectsWithTag("MenuWindow");
                    for (int i = 0; i < list.Length; i++)
                    {
                        list[i].GetComponent<Canvas>().enabled = false;
                    }
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        Debug.Log(obj.tag);
        if (insideTrash) {
            if (obj.CompareTag("Trash"))
            {
                insideTrash = false;
                obj.transform.GetChild(0).gameObject.SetActive(false);
                obj.transform.localScale = new Vector3(1, 1, 1);
                GameObject[] list = GameObject.FindGameObjectsWithTag("Menu");
                for (int i = 0; i < list.Length; i++)
                {
                    list[i].GetComponent<SpriteRenderer>().enabled = true;
                }

                list = GameObject.FindGameObjectsWithTag("MenuWindow");
                for (int i = 0; i < list.Length; i++)
                {
                    list[i].GetComponent<Canvas>().enabled = true;
                }
            }
        }
        
    }
}
