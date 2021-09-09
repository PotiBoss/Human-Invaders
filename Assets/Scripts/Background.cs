using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    [SerializeField] float backgroundScrollSpeed = 0.1f;
    Material myMaterial;
    Vector2 offSet;

    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        offSet = new Vector2(0f, backgroundScrollSpeed);
    }

    void Update()
    {
        myMaterial.mainTextureOffset += offSet * Time.deltaTime;
    }
}