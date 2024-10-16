/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPMenu : MonoBehaviour
{
    public GameObject menuPanel;
    public RectTransform menuRectTransform;

    private bool isMenuActive = false;

    void Update()
    {
        // Check if the spacebar is pressed to toggle the menu
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMenuActive = !isMenuActive;
            menuPanel.SetActive(isMenuActive);
        }

        // Right-click to close the menu (only close, not reopen)
        if (Input.GetMouseButtonDown(1))  // 1 is right mouse button
        {
            if (isMenuActive)
            {
                isMenuActive = false;
                menuPanel.SetActive(false);
            }
        }

        // Left-click outside the menu to close it
        if (Input.GetMouseButtonDown(0))  // 0 is left mouse button
        {
            if (isMenuActive && !IsPointerOverUIElement(menuRectTransform))
            {
                isMenuActive = false;
                menuPanel.SetActive(false);
            }
        }
    }

    // Helper method to check if the pointer is over the UI menu
    private bool IsPointerOverUIElement(RectTransform uiElement)
    {
        // Convert mouse position to a point in the world space of the UI canvas
        Vector2 localMousePosition = uiElement.InverseTransformPoint(Input.mousePosition);

        // Check if the click is within the bounds of the UI element's RectTransform
        return uiElement.rect.Contains(localMousePosition);
    }
}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // Import UI namespace for working with Text

public class GPMenu : MonoBehaviour
{
    public GameObject menuPanel;
    public RectTransform menuRectTransform;
    public TextMeshProUGUI coinText;  // Reference to the Text component that shows the number of coins
    public petVars pet;    // Reference to the petVars script to access critterCoin

    private bool isMenuActive = false;

    void Start()
    {
        // Update the coin display at the start
        UpdateCoinText();
    }

    void Update()
    {
        // Toggle the menu with the spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMenuActive = !isMenuActive;
            menuPanel.SetActive(isMenuActive);

            // Update the coin text whenever the menu is opened
            if (isMenuActive)
            {
                UpdateCoinText();
            }
        }

        // Right-click to close the menu
        if (Input.GetMouseButtonDown(1))  // 1 is right mouse button
        {
            if (isMenuActive)
            {
                isMenuActive = false;
                menuPanel.SetActive(false);
            }
        }

        // Left-click outside the menu to close it
        if (Input.GetMouseButtonDown(0))  // 0 is left mouse button
        {
            if (isMenuActive && !IsPointerOverUIElement(menuRectTransform))
            {
                isMenuActive = false;
                menuPanel.SetActive(false);
            }
        }
    }

    // Update the Text component to display the current critterCoin value
    void UpdateCoinText()
    {
        coinText.text = "Coins: " + pet.critterCoin.ToString();
    }

    // Helper method to check if the pointer is over the UI menu
    private bool IsPointerOverUIElement(RectTransform uiElement)
    {
        // Convert mouse position to a point in the world space of the UI canvas
        Vector2 localMousePosition = uiElement.InverseTransformPoint(Input.mousePosition);

        // Check if the click is within the bounds of the UI element's RectTransform
        return uiElement.rect.Contains(localMousePosition);
    }
}