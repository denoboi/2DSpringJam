using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int bonusDamage = 5; // The bonus damage given to the player

    public int GetBonusDamage()
    {
        return bonusDamage;
    }
}
