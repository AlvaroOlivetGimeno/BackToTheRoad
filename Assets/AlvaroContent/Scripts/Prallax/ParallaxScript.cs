using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("BACKGROUND PARALLAX VARIABLES:")]
    [Range(-10f, 5f)]
    public int layerOrder = 0;
    [Range(1f, 0f)]
    public float layerVelocity = 0.0f;

    float spriteLenght = 0.0f;
    float currentPosition = 0.0f;


   [Header("CAMERA OBJECT:")]
    public GameObject mainCamera; 

    
    private SpriteRenderer sRenderer;

    private float startPosition = 0.0f;



    void Start()
    {
        sRenderer = gameObject.GetComponent<SpriteRenderer>();

        InitParallaxLayer();


    }

    // Update is called once per frame
    void Update()
    {
        LayerMovement();
        SetSpritePosition();
    }

    public void InitParallaxLayer()
    {
        if(sRenderer != null)
        {
            sRenderer.sortingOrder = layerOrder;
            startPosition = mainCamera.transform.position.x;
            spriteLenght = sRenderer.bounds.size.x;
        }
    }

    public float GetDistance()
    {
        return mainCamera.transform.position.x * layerVelocity;
    }



    public void LayerMovement()
    {
        this.transform.position = new Vector3(startPosition + GetDistance(), transform.position.y, transform.position.z);
    }

    public void SetSpritePosition()
    {
        currentPosition = mainCamera.transform.position.x * (1 - layerVelocity);

        if(currentPosition> startPosition+spriteLenght)
        {
            startPosition += spriteLenght;
        }
        else if(currentPosition < startPosition - spriteLenght)
        {
            startPosition -= spriteLenght;
        }
    }
}
