using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShoeMenu : MonoBehaviour
{
    [SerializeField] private string shoeName;
    private string shoePrice;
    private string shoeType;
    private string shoeColour;
    private int[] shoeSize;

    private GameObject shoeGroundTracking;
    private GameObject shoeLeft;
    private GameObject shoeRight;
    public Renderer[] shoeLChildren;
    public Renderer[] shoeRChildren;
    public Renderer[] shoeGroundChildren;

    private ProductPlacement shoeScript;

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

        // Shoe productinfo
        shoeName = shoes.shoeName;
        shoePrice = shoes.shoePrice;
        shoeType = shoes.shoetype;
        shoeColour = shoes.shoeColour;
        shoeSize = shoes.shoeSize;

        SceneManager.LoadScene("1-Menu");
    }

    // Place the shoe on correct position for groundplane tracking
    void PlaceShoeGroundPlane()
    {
        // Find objects used to correctly place the shoe
        GameObject planemanager = GameObject.FindGameObjectWithTag("PlaneManager");
        GameObject target = GameObject.FindGameObjectWithTag("GroundPlaneTarget");

        // Instantiate the shoe
        GameObject placedShoe = Instantiate(shoeGroundTracking, target.transform);

        // Set planemanager script target to placed object
        planemanager.GetComponent<PlaneManager>().m_PlacementAugmentation = placedShoe;
        planemanager.GetComponent<PlaneManager>().m_PlaneAugmentation = placedShoe;

        // Set floor in script on shoe
        GameObject floor = GameObject.FindGameObjectWithTag("Floor");
        placedShoe.GetComponent<ProductPlacement>().Floor = floor.transform;

        shoeGroundChildren = placedShoe.GetComponentsInChildren<Renderer>();
    }

    void PlaceLeftRightShoes()
    {
        GameObject targetLeft = GameObject.FindGameObjectWithTag("TargetLeft");
        GameObject targetRight = GameObject.FindGameObjectWithTag("TargetRight");

        GameObject placedShoeLeft = Instantiate(shoeLeft, targetLeft.transform);
        GameObject placedShoeRight = Instantiate(shoeRight, targetRight.transform);

        shoeLChildren = placedShoeLeft.GetComponentsInChildren<Renderer>();
        shoeRChildren = placedShoeRight.GetComponentsInChildren<Renderer>();

        SetProductInfo();
    }

    public void SetProductInfo()
    {
        ProductInformation productInfo = GameObject.FindGameObjectWithTag("ProductInfo").GetComponent<ProductInformation>();

        productInfo.shoeName.text = shoeName;
        productInfo.shoePrice.text = "€ " + shoePrice;
        productInfo.shoeType.text = shoeType;
        productInfo.shoeColour.text = "KLEUR: " + shoeColour.ToUpper();

        productInfo.shoeSize.text = ""; // Remove template text
        foreach (var size in shoeSize)
        {
            productInfo.shoeSize.text += size + "\n";
        }
    }

    public void ChangeColour(Color color)
    {
        foreach (Renderer child in shoeLChildren)
        {
            if (child.tag == "ColourChange")
            {
                child.material.color = color;
            }
        }

        foreach (Renderer child in shoeRChildren)
        {
            if (child.tag == "ColourChange")
            {
                child.material.color = color;
            }
        }

        foreach (Renderer child in shoeGroundChildren) 
        {
            if(child.tag == "ColourChange") 
            {
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
