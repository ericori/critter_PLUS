using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophySystem : MonoBehaviour
{
    public void revealTrophy(GameObject trophy)
    {
        if(trophy.name == "Star")
        {
            trophy.SetActive(true);
        }

        if(trophy.name == "Trophy")
        {
            trophy.SetActive(true);
        }
    }
}
