using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGameScript : MonoBehaviour
{
    // Start is called before the first frame update


    GameObject[] inventorySlotsArray;
    bool bInventoryActive = false;


    [Header("INVENTORY VARIABLES:")]
    public int currentCookies;
    public int currentWaters;
    public int currentMedicines;
    public int currentGasolines;

    [Header("FEEDBACK TEXT GAME OBJECT:")]
    public GameObject feedbackText;


    void Start()
    {
        InitInventoryHUD();
    }

    // Update is called once per frame
    void Update()
    {
        HUDBehaviour();
    }

    public void InitInventoryHUD()
    {

        inventorySlotsArray = GameObject.FindGameObjectsWithTag("InventorySlot");

        if (inventorySlotsArray != null)
        {
            SetActivateStateOfSlots(false);
        }
    }

    public void SetActivateStateOfSlots(bool active)
    {
        foreach (var slot in inventorySlotsArray)
        {
            slot.SetActive(active);
        }
    }

    public void HUDBehaviour()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.I))
        {
            if (bInventoryActive)
            {
                CloseInventory();
            }
            else
            {
                OpenInventory();
            }
        }
    }

    public void OpenInventory()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        SetActivateStateOfSlots(true);
        bInventoryActive = true;

       
    }

    public void CloseInventory()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        SetActivateStateOfSlots(false);
        bInventoryActive = false;
    }

    public void ConsumeWater()
    {
        if(currentWaters != 0)
        {
            currentWaters -= 1;
            
            feedbackText.GetComponent<FeedbackTextScript>().SetFeedbackText("Water consumed");
        }
        else
        {
            
            feedbackText.GetComponent<FeedbackTextScript>().SetFeedbackText("There's NO more water");
        }
    }

    public void ConsumeCookie()
    {
        if (currentCookies != 0)
        {
            currentCookies -= 1;
            feedbackText.GetComponent<FeedbackTextScript>().SetFeedbackText("Cookie consumed. It was NICE!");
        }
        else
        {
            feedbackText.GetComponent<FeedbackTextScript>().SetFeedbackText("There's NO more cookies");
        }
    }

    public void ConsumeMedicine()
    {
        if (currentMedicines != 0)
        {
            currentMedicines -= 1;
            feedbackText.GetComponent<FeedbackTextScript>().SetFeedbackText("Me...me... Medicine con... sumed...");
        }
        else
        {
            feedbackText.GetComponent<FeedbackTextScript>().SetFeedbackText("There's NO more medicines");
        }
    }
    public void ConsumeGasoline()
    {
        if (currentGasolines != 0)
        {
            currentGasolines -= 1;
            feedbackText.GetComponent<FeedbackTextScript>().SetFeedbackText("GAAAAAASOLINEEEE CONSUUUMED!!!");
        }
        else
        {
            feedbackText.GetComponent<FeedbackTextScript>().SetFeedbackText("There's NO more gasoline");
        }
    }

}
