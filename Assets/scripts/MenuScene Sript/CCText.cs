using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CCText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void changeCCText(string ccText)
    {
        this.GetComponent<TextMeshProUGUI>().text = ccText;
    }
}
