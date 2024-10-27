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

    void Start()
    {
        petVariables = FindObjectOfType<petVars>(); // Finds the petVars instance in the scene
        namingPanel.SetActive(false); // Hide the naming panel initially

        // Add a listener to detect when the Enter key is pressed
        nameInputField.onSubmit.AddListener(delegate { SubmitName(); });
    }

    void Update()
    {
        // Check if friendRank in petVars has reached 4
        if (petVariables.friendRank == 4 && !namingPanel.activeSelf)
        {
            // Show the naming panel
            namingPanel.SetActive(true);
        }
    }

    // Call this method when the player submits the name
    public void SubmitName()
    {
        // Get the entered name
        string critterName = nameInputField.text;

        // Check if the input is empty
        if (!string.IsNullOrWhiteSpace(critterName))
        {
            // Display the name on the food bowl
            nameDisplayText.text = critterName;

            // Hide the naming panel after submission
            namingPanel.SetActive(false);
        }
    }
}
