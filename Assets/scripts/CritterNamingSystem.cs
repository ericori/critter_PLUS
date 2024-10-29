using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CritterNamingSystem : MonoBehaviour
{
    public GameObject namingPanel; // Panel that contains the prompt and input field
    public TMP_InputField nameInputField; // The TextMeshPro input field for the critter's name
    public TextMeshPro nameDisplayText; // The 3D TextMeshPro text on the food bowl
    private petVars petVariables; // Reference to the petVars script

    public bool nameSet = false;

    void Start()
    {
        petVariables = FindObjectOfType<petVars>(); // Finds the petVars instance in the scene
        namingPanel.SetActive(false); // Hide the naming panel initially
        
        // Optional: Add listener to the input field if you want Enter key to also close the panel
        nameInputField.onSubmit.AddListener(delegate { SubmitName(); });
    }

    void Update()
    {
        // Check if friendRank in petVars has reached 4
        if (petVariables.friendRank == 4 && !namingPanel.activeSelf && nameSet == false)
        {
            // Show the naming panel
            namingPanel.SetActive(true);
        }
    }

    // Call this method when the player submits the name
    public void SubmitName()
    {
        string critterName = nameInputField.text;

        if (!string.IsNullOrWhiteSpace(critterName))
        {
            nameDisplayText.text = critterName;
            CloseNamingPanel(); // Close the naming panel after submitting
            nameSet = true;
        }
    }

    // Method to close the naming panel
    public void CloseNamingPanel()
    {
        namingPanel.SetActive(false);
    }
}
