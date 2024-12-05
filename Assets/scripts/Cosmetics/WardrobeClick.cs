using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardrobeClick : MonoBehaviour
{
    public GameObject character; // Reference to the character GameObject
    public Sprite wizardHat; // Sprite for the wizard hat
    public Sprite crown; // Sprite for the crown
    public SpriteRenderer hatRenderer; // Renderer for the hat slot

    public int currentHat = 0; // 0: no hat, 1: wizard hat, 2: crown

    void Start()
    {
        if (character != null)
        {
            // Get the SpriteRenderer from the HatSlot child
            hatRenderer = character.transform.Find("HatSlot").GetComponent<SpriteRenderer>();
        }
    }

    void OnMouseDown()
    {
        if (hatRenderer == null) return;

        // Cycle hats: 0 (no hat) -> 1 (wizard hat) -> 2 (crown) -> repeat
        currentHat = (currentHat + 1) % 3;

        switch (currentHat)
        {
            case 0:
                hatRenderer.sprite = null; // No hat
                break;
            case 1:
                hatRenderer.sprite = wizardHat; // Wizard hat
                break;
            case 2:
                hatRenderer.sprite = crown; // Crown
                break;
        }
    }
}
