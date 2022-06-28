using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonFunc : MonoBehaviour
{
    public MultiTouch mt;

    public void NewCharacter(GameObject myCharacter)
    {
        Instantiate(myCharacter, new Vector3(Random.Range(-10, 10), Random.Range(-2.5f, 2.5f), 0), Quaternion.identity);
    }

    public void StartCollab()
    {
        SceneManager.LoadScene("CollabStage");
    }

    public void Home()
    {
        SceneManager.LoadScene("Start");
    }

    public void Active(GameObject obj)
    {
        if (mt.index != -1)
        {
            Camera.main.GetComponent<SharedData>().touches[mt.index] = false;
            mt.index = -1;
        }
        obj.SetActive(false);
    }

    public void ChangeBackground()
    {
        GameObject.Find("Canvas").GetComponent<Image>().sprite = GetComponent<Image>().sprite;
        GameObject.Find("Directional Light").GetComponent<Light>().color = GetComponent<Button>().colors.selectedColor;
        GameObject.Find("Ambient Light").GetComponent<Light>().color = GetComponent<Button>().colors.disabledColor;
    }
}
