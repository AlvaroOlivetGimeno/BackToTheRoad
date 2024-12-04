using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FeedbackTextScript : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI textMeshProUGUI;

    bool activeFeedbackText = false;

    [Range(1f, 3f)]
    public float feedbackMessageTime = 0.0f;
    float currentFeedbackMessageTime = 0.1f;

    void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        this.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(activeFeedbackText)
        {
            currentFeedbackMessageTime += 0.01f;

            if(currentFeedbackMessageTime > (feedbackMessageTime*10) )
            {
                DesactiveFeedbackText();
            }
        }
    }

    public void SetFeedbackText(string feedbackText)
    {
        textMeshProUGUI.text = feedbackText;
        this.gameObject.SetActive(true);
        activeFeedbackText = true;
        currentFeedbackMessageTime = 0.0f;
    }

    public void DesactiveFeedbackText()
    {
       // Debug.Log("dESACTIVANDO");
        currentFeedbackMessageTime = 0.1f;
        activeFeedbackText = false;
        this.gameObject.SetActive(false);
    }


}
