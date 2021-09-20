using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlant : MonoBehaviour
{
    public void Plant(GameObject plant)
    {
        Instantiate(plant);
    }
}
