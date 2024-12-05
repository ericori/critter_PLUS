using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class subtitleManager : MonoBehaviour
{
    public Text subtitleText;
    public TextAsset subtitles;
    public Toggle subtitleToggle;

    private bool subtitlesEnabled = false; //disabled by default
    private string[] subtitleLines = {"[happy bark]"}; //Store subtitle lines here

    // Start is called before the first frame update
    void Start()
    {
        if (subtitles != null)
        {
            subtitleLines = subtitles.text.Split('\n');
        }
    }

    public void DisplaySubtitle(int index, float duration)
    {
        if (subtitlesEnabled && subtitleText != null && subtitleLines != null && index < subtitleLines.length)
        {
            subtitleText.text = subtitleLines[index];
            Invoke(nameof(ClearSubtitle), duration);
        }
        else
        {
            subtitleText.text = "";
        }
    }
}
