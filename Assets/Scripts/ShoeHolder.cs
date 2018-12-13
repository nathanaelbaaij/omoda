using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoeHolder : MonoBehaviour
{
    [Header("Shoe prefabs")]
    public GameObject shoeGroundTracking;
    public GameObject shoeLeft;
    public GameObject shoeRight;

    [Header("Shoe productinfo")]
    public string shoeName;
    public string shoePrice;
    public string shoetype;
    public string shoeColour;
    public int[] shoeSize;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
