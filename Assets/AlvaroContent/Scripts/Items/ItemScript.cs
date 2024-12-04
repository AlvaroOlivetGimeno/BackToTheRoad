using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("ITEM DATA:")]
    public ItemData ItemData;

     SpriteRenderer spriteRenderer;
    private CircleCollider2D circleCollider;

    


    private GameObject inventoryGame;

    void Start()
    {
        InitItem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitItem()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
        inventoryGame = GameObject.FindGameObjectWithTag("HUD");
        spriteRenderer.sprite = ItemData.GetImage();
       
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            inventoryGame.GetComponent<InventoryGameScript>().AddItemToInventory(ItemData.GetItem());
            Destroy(this.gameObject);
        }
    }

}
