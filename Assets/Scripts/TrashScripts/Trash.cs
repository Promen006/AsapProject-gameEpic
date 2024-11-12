using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public enum TrashType
    {
        Ground,   // Наземный мусор
        Air       // Воздушный мусор
    }

    public TrashType trashType;
}
