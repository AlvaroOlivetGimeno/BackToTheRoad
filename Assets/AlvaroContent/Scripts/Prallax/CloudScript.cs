using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;

    [Header("CLOUD SPRITES:")]
    public Sprite[] spritesArray;
    private GameObject cloudsFolder;

    public float cloudVelocity = 0.0f;
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        cloudsFolder = GameObject.FindGameObjectWithTag("CloudFolder");

        InitCloud();

        Invoke("DestroyMyself", 20f);

    }

    // Update is called once per frame
    void Update()
    {
        CloudMovment();
    }

    public void CloudMovment()
    {
        float newXposition = transform.position.x - (cloudVelocity * Time.deltaTime);
        this.gameObject.transform.position = new Vector3(newXposition, transform.position.y, transform.position.z);
    }

    public void InitCloud()
    {
        if(cloudsFolder != null)
        {
            this.transform.SetParent(cloudsFolder.transform, false);
        }
       
        cloudVelocity = Random.Range(1.0f, 10.0f);
        spriteRenderer.sprite = spritesArray[Random.Range(0, spritesArray.Length - 1)];
        spriteRenderer.sortingOrder = Random.Range(-10, -5);
        float newScale = Random.Range(0.5f, 3.0f);
        this.transform.localScale = new Vector3(newScale, newScale, newScale);
    }

    public void DestroyMyself()
    {
        Destroy(this.gameObject);
    }

    public void SetOrderInLayer(int layer)
    {
        spriteRenderer.sortingOrder = layer;
    }
}
