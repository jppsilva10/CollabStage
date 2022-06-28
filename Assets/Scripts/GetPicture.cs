using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class GetPicture : MonoBehaviour
{
    public GameObject obj;
    public string name;

    // Start is called before the first frame update
    void Start()
    {
        /*
        Texture2D img = AssetPreview.GetAssetPreview(obj);
        File.WriteAllBytes("Assets/Sprites/Characters/" + name, img.EncodeToPNG()) ;
        */
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
