using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public float range = 5f;
    public float rotationScale = 1f;
    public float test;

    private MultiTouch mt;

    public GameObject[] icons;
    public GameObject[] windows;

    // Start is called before the first frame update
    void Start()
    {
        mt = GetComponent<MultiTouch>();
    }

    private bool IsCloseToAngle(float angle = 0, float diff=0)
    {

        float difference = ((Vector3.SignedAngle(transform.parent.up, transform.up, Vector3.forward) +360)%360) - angle;

        if (angle == 0 && (difference + angle)>=360-diff)
        {
            return true;
        }

        return (difference <= diff && difference >= -diff);
    }

    private void SetRotation(float angle)
    {
        icons[(int)(angle / 60)].SetActive(false);
        if (IsCloseToAngle(angle, 30))
        {
            icons[(int)(angle / 60)].SetActive(true);
            transform.up += Quaternion.AngleAxis(angle, Vector3.forward) * transform.parent.up - transform.up * Time.deltaTime * rotationScale;
        }
    }

    private void AjustRotation()
    {
        for(int i=0; i<=300; i += 60)
        {
            icons[i/60].SetActive(false);
            if (windows[i / 60] != null)
            {
                windows[i / 60].SetActive(false);
            }
            if (IsCloseToAngle(i, 30))
            {
                icons[i/60].SetActive(true);
                if (windows[i / 60] != null)
                {
                    windows[i / 60].SetActive(true);
                }
                if (mt.index < 0) 
                { 
                    float angulo = ((Vector3.SignedAngle(transform.parent.up, transform.up, Vector3.forward) + 360) % 360);
                    if (angulo >= 330)
                    {
                        angulo += (360 - angulo) * Time.deltaTime * rotationScale;
                    }
                    else
                    {
                        angulo += (i - angulo) * Time.deltaTime * rotationScale;
                    }
                    
                    transform.up = Vector3.up;
                    transform.Rotate(0, 0, Vector3.SignedAngle(transform.up, transform.parent.up, Vector3.forward));
                    transform.Rotate(0, 0, angulo);
                }

                //transform.up += transform.up + (Quaternion.Euler(0, 0, i) * Vector3.up - transform.up) * Time.deltaTime * rotationScale;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        AjustRotation();
        /*
        for (int i = 60; i <= 360; i += 60)
        {
            icons[((360 - i) % 360) / 60].SetActive(false);
            if (IsCloseToAngle(i, 30))
            {
                icons[((360 - 1) % 360) / 60].SetActive(true);
                transform.up = Quaternion.Euler(0, 0, i) * Vector3.up;
                //transform.up += transform.up + (Quaternion.Euler(0, 0, i) * Vector3.up - transform.up) * Time.deltaTime * rotationScale;
                break;
            }
        }
        */
    }
}
