using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShoeMenu : MonoBehaviour
{
    [SerializeField] private GameObject selectedShoe;


    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject); // Do not destroy the ShoeManager on load
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "3-GroundPlane")
        {
            PlaceShoeGroundPlane();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectShoe(GameObject shoe)
    {
        selectedShoe = shoe;
        if (selectedShoe != null)
        {
            SceneManager.LoadScene("1-Menu");
        }
    }

    // Place the shoe on correct position for groundplane tracking
    void PlaceShoeGroundPlane()
    {
        GameObject target = GameObject.FindGameObjectWithTag("GroundPlaneTarget");

        GameObject placedShoe = Instantiate(selectedShoe, target.transform);
    }
}
