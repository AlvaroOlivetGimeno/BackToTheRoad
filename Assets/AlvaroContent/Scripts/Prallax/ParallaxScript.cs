using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ParallaxScript : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("BACKGROUND PARALLAX VARIABLES:")]
    [Range(-10f, 5f)]
    public int layerOrder = 0;
    [Range(1f, 0f)]
    public float layerVelocity = 0.0f;

    [Header("CAMERA OBJECT:")]
    public GameObject mainCamera;



   
    private float spriteLenght = 0.0f;
    private float currentPosition = 0.0f;
    private float startPosition = 0.0f;
    private SpriteRenderer sRenderer;

    void Start()
    {
        InitParallaxLayer();

    }

    // Update is called once per frame
    void Update()
    {
       
        SetSpritePosition();
    }

    public void InitParallaxLayer()
    {
        sRenderer = gameObject.GetComponent<SpriteRenderer>();

        if (sRenderer != null)
        {
            sRenderer.sortingOrder = layerOrder;
            startPosition = this.transform.position.x;
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
            SpawnParallax();
           

        }
        else if(currentPosition < startPosition - spriteLenght)
        {
            startPosition -= spriteLenght;
            SpawnParallax();
        }
        else
        {
            LayerMovement();
        }
    }

    public void SpawnParallax()
    {

        GameObject newParallax = Instantiate(this.gameObject, new Vector3(startPosition, transform.position.y, transform.position.z), transform.rotation);
        newParallax.GetComponent<ParallaxScript>().mainCamera = mainCamera;
        Invoke("DestroyMyself", 1.5f);
    }

    public void DestroyMyself()
    {
        Destroy(this.gameObject);
    }

}
