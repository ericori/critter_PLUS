using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MENUcaptionSettings : MonoBehaviour
{
    public Button toggleButton;

    void Start()
    {

        UpdateButtonLabel();

        toggleButton.onClick.AddListener(ToggleSubtitles);
    }

    void ToggleSubtitles()
    {
        captionSettings.CaptionsEnabled = !captionSettings.CaptionsEnabled;

        UpdateButtonLabel();

        Debug.Log("captions are now " + (captionSettings.CaptionsEnabled ? "On" : "Off"));
    }

    void UpdateButtonLabel()
    {
        toggleButton.GetComponentInChildren<TMPro.TMP_Text>().text =
            "CAPTIONS: " + (captionSettings.CaptionsEnabled ? "ON" : "OFF");
    }
}
