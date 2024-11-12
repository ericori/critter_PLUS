using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class toggleColorInversion : MonoBehaviour
{
    public Material normalMaterial;
    public Material invertMaterial;

    private bool isInverted = false;
    public bool invertCanvas = false;

    //public GameObject canvas;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check for a mouse click
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("LightSwitch"))
            {
                ToggleInversion();
            }
        }
    }

    void ToggleInversion()
    {
        isInverted = !isInverted;
        invertCanvas = isInverted;

        // Toggle material on all renderers in the scene
        SpriteRenderer[] renderers = FindObjectsOfType<SpriteRenderer>();

        foreach (SpriteRenderer renderer in renderers)
        {
            renderer.material = isInverted ? invertMaterial : normalMaterial;
        }

        /*
        canvas.GetComponent<CanvasRenderer>().SetMaterial(isInverted ? invertMaterial : normalMaterial, 0);
        if(canvas.GetComponent<Outline>() != null)
         {
            canvas.GetComponent<Outline>().enabled = isInverted;
         }
        */
        
    }
}