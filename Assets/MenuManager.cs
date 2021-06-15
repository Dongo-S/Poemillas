using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour
{

    [SerializeField] Image storyImage;
    RectTransform imageRect;

    Vector2 anchoredPosition;

    [SerializeField] DataScenesValues values;




    private void OnValidate()
    {
        imageRect = storyImage.GetComponent<RectTransform>();
        anchoredPosition = imageRect.anchoredPosition;

        if (values.storyHasBeenSeenRuntime)
        {
            Debug.Log(values.storyHasBeenSeenRuntime);
            ChangePosition(1f);
            //ShowInstructions();   
        }
    }

    public void Start()
    {
        imageRect = storyImage.GetComponent<RectTransform>();
        anchoredPosition = imageRect.anchoredPosition;

        if (values.storyHasBeenSeenRuntime)
        {
            Debug.Log(values.storyHasBeenSeenRuntime);
            ChangePosition(1f);
            //ShowInstructions();   
        }
        else
        {
            ChangePosition(0f);
        }
    }

    public void ChangePosition(float value)
    {


        anchoredPosition.y = value * (imageRect.sizeDelta.y - 1080);

        imageRect.anchoredPosition = anchoredPosition;
    }

}
