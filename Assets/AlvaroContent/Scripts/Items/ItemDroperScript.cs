using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDroperScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject playerCharacter;

    [Header("DROPPING ITEM DISTANCE:")]
    [Range(0.1f, 20.0f)]
    public float rateForDroppingItems = 0.0f;
    float currentTimeForDroppingItems = 0.0f;

    [Header("ITEMS TO DROP:")]
    public GameObject[] itemsArray;


    void Start()
    {
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
        Instantiate(GetRandomItem(), this.transform.position, this.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        DropItem();
    }

    public void DropItem()
    {
        if(playerCharacter.GetComponent<CarMovmentScript>().GetHorizontalAxisValue() != 0)
        {
            currentTimeForDroppingItems += Time.deltaTime; // * rateForDroppingItems;

            //Debug.Log(currentTimeForDroppingItems);

            if(currentTimeForDroppingItems>=rateForDroppingItems)
            {
                Instantiate(GetRandomItem(), this.transform.position, this.transform.rotation);
                currentTimeForDroppingItems = 0;
            }
        }
    }
    public GameObject GetRandomItem()
    {

        int randomVar = Random.Range(0, itemsArray.Length-1); 

        return itemsArray[randomVar];
    }
}
