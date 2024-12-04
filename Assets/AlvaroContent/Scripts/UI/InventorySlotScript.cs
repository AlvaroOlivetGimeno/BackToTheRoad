using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    private enum ItemsType { Cookie, Water, Medicine, Gasoline };
    [Header("INVENTORY SLOT TYPE:")]
    [SerializeField]  ItemsType SlotItem;

    [Header("INVENTORY SLOT COMPONENTS:")]
    public GameObject inventoryImage;
    public GameObject inventoryText;


    [Header("IMAGE OF INVENTORY ITEMS:")]
    public Sprite cookieImage;
    public Sprite waterImage;
    public Sprite medicineImage;
    public Sprite gasolineImage;

    void Start()
    {
       
        InitInventorySlot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        switch (SlotItem)
        {
            case ItemsType.Cookie:
                transform.GetComponentInParent<InventoryGameScript>().ConsumeCookie();
                inventoryText.GetComponent<TextMeshProUGUI>().text = transform.GetComponentInParent<InventoryGameScript>().currentCookies.ToString();
                break;
            case ItemsType.Water:
                transform.GetComponentInParent<InventoryGameScript>().ConsumeWater();
                inventoryText.GetComponent<TextMeshProUGUI>().text = transform.GetComponentInParent<InventoryGameScript>().currentWaters.ToString();
                break;
            case ItemsType.Medicine:
                transform.GetComponentInParent<InventoryGameScript>().ConsumeMedicine();
                inventoryText.GetComponent<TextMeshProUGUI>().text = transform.GetComponentInParent<InventoryGameScript>().currentMedicines.ToString();
                break;
            case ItemsType.Gasoline:
                transform.GetComponentInParent<InventoryGameScript>().ConsumeGasoline();
                inventoryText.GetComponent<TextMeshProUGUI>().text = transform.GetComponentInParent<InventoryGameScript>().currentGasolines.ToString();
                break;
        }

    }

    public void InitInventorySlot()
    {
        switch (SlotItem)
        {
            case ItemsType.Cookie:
                inventoryImage.GetComponent<Image>().sprite = cookieImage;
                inventoryText.GetComponent<TextMeshProUGUI>().text = transform.GetComponentInParent<InventoryGameScript>().currentCookies.ToString();
                break;
            case ItemsType.Water:
                inventoryImage.GetComponent<Image>().sprite = waterImage;
                inventoryText.GetComponent<TextMeshProUGUI>().text=transform.GetComponentInParent<InventoryGameScript>().currentWaters.ToString();
                break;
            case ItemsType.Medicine:
                inventoryImage.GetComponent<Image>().sprite = medicineImage;
                inventoryText.GetComponent<TextMeshProUGUI>().text = transform.GetComponentInParent<InventoryGameScript>().currentMedicines.ToString();
                break;
            case ItemsType.Gasoline:
                inventoryImage.GetComponent<Image>().sprite = gasolineImage;
                inventoryText.GetComponent<TextMeshProUGUI>().text = transform.GetComponentInParent<InventoryGameScript>().currentGasolines.ToString();
                break;
        }
    }

   
    


}
