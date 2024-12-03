using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    // Start is called before the first frame update

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
        RoadSpawnBehaviour();
    }

    public void InitParallaxLayer()
    {
        sRenderer = gameObject.GetComponent<SpriteRenderer>();

        if (sRenderer != null)
        {
            startPosition = this.transform.position.x;
            spriteLenght = sRenderer.bounds.size.x;
        }
    }

    public void RoadSpawnBehaviour()
    {
        currentPosition = mainCamera.transform.position.x;

        if (currentPosition > startPosition + spriteLenght)
        {
            startPosition += spriteLenght;
            SpawnNewRoad();


        }
        else if (currentPosition < startPosition - spriteLenght)
        {
            startPosition -= spriteLenght;
            SpawnNewRoad();
        }
        
    }

    public void SpawnNewRoad()
    {

        GameObject newRoad = Instantiate(this.gameObject, new Vector3(startPosition, transform.position.y, transform.position.z), transform.rotation);
        newRoad.GetComponent<FloorScript>().mainCamera = mainCamera;
        Invoke("DestroyMyself", 0.5f);
    }

    public void DestroyMyself()
    {
        Destroy(this.gameObject);
    }
}
