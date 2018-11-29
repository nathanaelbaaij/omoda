using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShoeMenu : MonoBehaviour
{
    public GameObject shoeGroundTracking;
    public GameObject shoeLeft;
    public GameObject shoeRight;
    public Renderer[] shoeLChildren;
    public Renderer[] shoeRChildren;

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

        if (scene.name == "ImageTracking")
        {
            PlaceLeftRightShoes();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectShoe(ShoeHolder shoes)
    {
        shoeGroundTracking = shoes.shoeGroundTracking;
        shoeLeft = shoes.shoeLeft;
        shoeRight = shoes.shoeRight;

        SceneManager.LoadScene("1-Menu");
    }

    // Place the shoe on correct position for groundplane tracking
    void PlaceShoeGroundPlane()
    {
        GameObject target = GameObject.FindGameObjectWithTag("GroundPlaneTarget");

        GameObject placedShoe = Instantiate(shoeGroundTracking, target.transform);
    }

    void PlaceLeftRightShoes()
    {
        GameObject targetLeft = GameObject.FindGameObjectWithTag("TargetLeft");
        GameObject targetRight = GameObject.FindGameObjectWithTag("TargetRight");

        GameObject placedShoeLeft = Instantiate(shoeLeft, targetLeft.transform);
        GameObject placedShoeRight = Instantiate(shoeRight, targetRight.transform);

        shoeLChildren = placedShoeLeft.GetComponentsInChildren<Renderer>();
        shoeRChildren = placedShoeRight.GetComponentsInChildren<Renderer>();

        //ChangeColour();
    }

    public void ChangeColour(Color color) {
        foreach(Renderer child in shoeLChildren) {
            if(child.tag == "ColourChange") {
                child.material.color = color;
            }
        }

        foreach(Renderer child in shoeRChildren) {
            if(child.tag == "ColourChange") {
                child.material.color = color;
            }
        }
    }

    public void BackButton()
    {
        Application.Quit();
        Debug.Log("Quitting application");
    }
}
