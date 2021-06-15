using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScalePrinter : MonoBehaviour
{
    //public UnityEngine.UI.Text textScale;

    public int timeScale;
    public bool ignoreInt;
    [Space]
    public UnityEngine.UI.Text winRateText;
    int wins;
    int loses;
    public void AddWin()
    {
        wins++;
        SetWinRate();
    }


    public void AddLose()
    {
        loses++;

        SetWinRate();
    }


    void SetWinRate()
    {
        winRateText.text = string.Format("Win rate: {0:0.00}%", ((float)wins / (wins + loses) * 100f));
        
    }
    private void Awake()
    {


    }

    private void Start()
    {
        if (!ignoreInt)
            Time.timeScale = timeScale;
       // textScale.text = "Time Scale: " + Time.timeScale;

    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Time.timeScale = 1f;
            //textScale.text = "Time Scale: " + Time.timeScale;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Time.timeScale = 0.5f;
            //textScale.text = "Time Scale: " + Time.timeScale;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Time.timeScale = 0.10f;
           // textScale.text = "Time Scale: " + Time.timeScale;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Time.timeScale = 0.05f;
           // textScale.text = "Time Scale: " + Time.timeScale;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Time.timeScale = 0.20f;
           // textScale.text = "Time Scale: " + Time.timeScale;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Time.timeScale = 0.25f;
           // textScale.text = "Time Scale: " + Time.timeScale;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            Time.timeScale = 0.30f;
          //  textScale.text = "Time Scale: " + Time.timeScale;
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Time.timeScale = 35f;
            //textScale.text = "Time Scale: " + Time.timeScale;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Time.timeScale =0.40f;
            //textScale.text = "Time Scale: " + Time.timeScale;
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Time.timeScale *= 2f;
            //textScale.text = "Time Scale: " + Time.timeScale;
        }

    }
}
