using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class updatePetVars : MonoBehaviour
{
    public TextMeshProUGUI affectionText;
    public TextMeshProUGUI hungerText;
    public TextMeshProUGUI coinText;

    public petVars pet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        affectionText.text = pet.affection.ToString();
        hungerText.text = pet.hunger.ToString();
        coinText.text = pet.critterCoin.ToString();
    }
}
