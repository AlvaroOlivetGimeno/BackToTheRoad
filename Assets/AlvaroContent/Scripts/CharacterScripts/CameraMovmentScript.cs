using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovmentScript : MonoBehaviour
{
    // Start is called before the first frame update

   
    [Header("Player TAG:")]
    public string playerTag ="";
    GameObject playerCharacter = null;

    [Header("Camera Movment Variables:")]
    [Range(0.1f, 10f)]
    public float cameraOffset = 0.0f;
    float currentCameraOffset = 0.0f;
    [Range(0.1f, 5f)]
    public float cameraOffsetSmothing = 0.0f;


    void Start()
    {
        playerCharacter = GameObject.FindGameObjectWithTag(playerTag);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerCharacter != null)
        {
            this.transform.position = new Vector3(playerCharacter.transform.position.x + currentCameraOffset, this.transform.position.y, this.transform.position.z);
            
            if(playerCharacter.GetComponent<CarMovmentScript>().GetHorizontalAxisValue() == 1)
            {
                if(currentCameraOffset < cameraOffset)
                {
                    currentCameraOffset += cameraOffsetSmothing / 100;
                }
                else 
                {
                    currentCameraOffset = cameraOffset;
                }
                
            }
            else 
            {
                if (currentCameraOffset > 0)
                {
                    currentCameraOffset -= cameraOffsetSmothing / 100;
                }
                else
                {
                    currentCameraOffset = 0;
                }
            }
            Debug.Log(currentCameraOffset);

            


        }
        else
        {
            Debug.LogWarning("Character NOT found!");
        }
       
    }
}
