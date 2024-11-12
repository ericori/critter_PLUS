using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class darkMode : MonoBehaviour
{
    private Material canvasMaterial = null;
    public toggleColorInversion toggle;
    public TextMeshProUGUI[] textChange;

    // Start is called before the first frame update
    void Start()
    {
        textChange = FindObjectsOfType<TextMeshProUGUI>();
    }

    // Update is called once per frame
    public void lightAndDarkMode()
    {
        textChange = FindObjectsOfType<TextMeshProUGUI>();

        for (int i = 0; i < textChange.Length; i++)
        {
            if (textChange[i].name == "Hunger Text")
            {
                //do nothing
            }

            else
            {
                if (toggle.invertCanvas)
                {
                    textChange[i].color = Color.white;
                }

                else
                {
                    textChange[i].color = Color.black;
                }
            }           
        }

        if(gameObject.activeSelf == true)
        {
            if (toggle.invertCanvas)
            {
                gameObject.GetComponent<Image>().color = Color.black;
            }
            else
            {
                gameObject.GetComponent<Image>().color = Color.white;
            }
            
            if (gameObject.GetComponent<Outline>() != null)
            {
                gameObject.GetComponent<Outline>().enabled = toggle.invertCanvas;
            }
        }
    }
}
