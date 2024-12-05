using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class shoppingMenuV2 : MonoBehaviour
{
    public GameObject menuPanel; // Shopping panel (Laptop overlay)
    public RectTransform menuRectTransform; // Menu bounds for clicking detection
    public TextMeshProUGUI ccoinText; // Text to display Critter Coins
    public TextMeshProUGUI kibbleText; // Text to display the number of kibble
    public TextMeshProUGUI shopTitleText; // Text for the shop title
    public Button buyKibbleButton; // Buy button for kibble
    public Button buyCrownHat;
    public Button buyWizsoftCap;
    public bool isCrownPurchased = false;
    public bool isWizsoftCapPurchased = false;

    public int kibblePrice = 10; // Cost of one kibble
    public int crownPrice = 500;
    public int wizsoftPrice = 100;

    private bool isMenuActive = false;
    private petVars pet; // Reference to petVars for shared critterCoin and kibbleCount

    void Start()
    {
        // Find the petVars component in the scene
        pet = FindObjectOfType<petVars>();

        // Check if menuPanel is assigned to avoid null reference errors
        if (menuPanel == null)
        {
            Debug.LogError("Menu Panel is not assigned in the Inspector.");
        }
        else
        {
            // Initially hide the menu
            menuPanel.SetActive(false);
        }

        // Set initial title text for the shop
        if (shopTitleText != null)
        {
            shopTitleText.text = "Critter Store";
        }
        else
        {
            Debug.LogError("Shop Title Text is not assigned in the Inspector.");
        }

        // Initialize UI with current values
        UpdateUI();

        // Add a listener to the buy kibble button, with a null check
        if (buyKibbleButton != null)
        {
            buyKibbleButton.onClick.AddListener(BuyKibble);
        }
        else
        {
            Debug.LogError("Buy Kibble Button is not assigned in the Inspector.");
        }
        if (buyCrownHat != null)
        {
            buyCrownHat.onClick.AddListener(BuyCrown);
        }
        else
        {
            Debug.LogError("Buy Crown Button is not assigned in the Inspector.");
        }
        if (buyWizsoftCap != null)
        {
            buyWizsoftCap.onClick.AddListener(BuyWizsoftCap);
        }
        else
        {
            Debug.LogError("Buy WizsoftCap Button is not assigned in the Inspector.");
        }
    }

    void Update()
    {
        // Toggle the menu with the L key
        if (Input.GetKeyDown(KeyCode.L))
        {
            ToggleMenu();
        }

        // Right-click to close the menu
        if (Input.GetMouseButtonDown(1) && isMenuActive)
        {
            CloseMenu();
        }

        // Left-click outside the menu to close it
        if (Input.GetMouseButtonDown(0) && isMenuActive && !IsPointerOverUIElement(menuRectTransform))
        {
            CloseMenu();
        }

        // Ensure the UI is constantly synced with `petVars` values
        UpdateUI();
    }

    // Helper function to check if pointer is over UI
    private bool IsPointerOverUIElement(RectTransform uiElement)
    {
        Vector2 localMousePosition = uiElement.InverseTransformPoint(Input.mousePosition);
        return uiElement.rect.Contains(localMousePosition);
    }

    // Method to handle kibble purchases
    private void BuyKibble()
    {
        if (pet != null && pet.critterCoin >= kibblePrice)
        {
            pet.critterCoin -= kibblePrice;
            pet.kibbleCount++; // Increase the kibble count in petVars
            UpdateUI(); // Update the UI immediately after purchase
            Debug.Log("Kibble purchased!");
        }
        else if (pet != null && pet.critterCoin < kibblePrice)
        {
            Debug.Log("Not enough Critter Coins to buy kibble.");
        }
        else
        {
            Debug.LogError("petVars reference is missing.");
        }
    }

    private void BuyCrown()
    {
        if (pet != null && pet.critterCoin >= crownPrice && isCrownPurchased == false)
        {
            pet.critterCoin -= crownPrice;
            isCrownPurchased = true;
            UpdateUI(); // Update the UI immediately after purchase
            Debug.Log("Crowm purchased!");
        }
        else if (pet != null && pet.critterCoin < crownPrice)
        {
            Debug.Log("Not enough Critter Coins to buy kibble.");
        }
        else
        {
            Debug.LogError("petVars reference is missing.");
        }
    }

    private void BuyWizsoftCap()
    {
        if (pet != null && pet.critterCoin >= wizsoftPrice && isWizsoftCapPurchased == false)
        {
            pet.critterCoin -= wizsoftPrice;
            isWizsoftCapPurchased = true;
            UpdateUI(); // Update the UI immediately after purchase
            Debug.Log("Kibble purchased!");
        }
        else if (pet != null && pet.critterCoin < kibblePrice)
        {
            Debug.Log("Not enough Critter Coins to buy kibble.");
        }
        else
        {
            Debug.LogError("petVars reference is missing.");
        }
    }

    // Method to update the text display
    private void UpdateUI()
    {
        if (pet != null)
        {
            ccoinText.text = "Critter Coins: " + pet.critterCoin;
            kibbleText.text = "Total Kibble: " + pet.kibbleCount;
        }
        else
        {
            Debug.LogError("petVars reference is missing.");
        }
    }

    // Method to toggle the shopping menu
    public void ToggleMenu()
    {
        isMenuActive = !isMenuActive;

        // Check if menuPanel is assigned before activating/deactivating
        if (menuPanel != null)
        {
            menuPanel.SetActive(isMenuActive);
            UpdateUI(); // Update the UI whenever the menu is opened
        }
    }

    // Method to close the shopping menu
    public void CloseMenu()
    {
        isMenuActive = false;

        // Check if menuPanel is assigned before deactivating
        if (menuPanel != null)
        {
            menuPanel.SetActive(false);
        }
    }

    // Method to check if the menu is active
    public bool IsMenuActive()
    {
        return isMenuActive;
    }
}
