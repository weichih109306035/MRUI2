using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class DebugLogReader : MonoBehaviour
{
    public TMP_Text textInput;
    private string logContent = "";

    private void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }
    private void HandleLog(string logString, string stackTrace, LogType type)
    {
        if (type == LogType.Log)
        {
            List<string> logList = new List<string>(logString.Split(','));
            if (logList.Count > 0)
            {
                logContent = logList[logList.Count - 1].Substring(1, logList[logList.Count - 1].Length - 3);
            }
            else
            {
                logContent = "Start";
            }


            UpdateTextInput();
        }
    }

    private void UpdateTextInput()
    {
        textInput.text = logContent;
    }

}
