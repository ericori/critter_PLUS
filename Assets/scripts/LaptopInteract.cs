using UnityEngine;

public class LaptopInteract : MonoBehaviour
{
    public shoppingMenuV2 shoppingMenu; // Reference to the shoppingMenuV2 script

    private void OnMouseDown()
    {
        // Only open the shopping menu if it is currently closed
        if (shoppingMenu != null && !shoppingMenu.IsMenuActive())
        {
            shoppingMenu.ToggleMenu(); // Open the menu
        }
    }
}

