using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShoeMenu : MonoBehaviour
{
    [SerializeField] private GameObject chosenShoe;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject); // Do not destroy the ShoeManager on load
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectShoe(GameObject shoe)
    {
        chosenShoe = shoe;
        if (chosenShoe != null)
        {
            SceneManager.LoadScene("1-Menu");
        }
    }
}
