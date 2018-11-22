using UnityEngine;
using Vuforia;

// rename this class to suit your needs
public class LoadObject : MonoBehaviour
{
    // the Equip prefab - required for instantiation
    public GameObject equipPrefab_links;
    public Transform parent_links;
    public GameObject equipPrefab_rechts;
    public Transform parent_rechts;
   
    void Start()
    {
    }

    public void CreateObject()
    {
        foreach (Transform child in parent_links)
        {
            GameObject.Destroy(child.gameObject);
        }
        foreach (Transform child in parent_rechts)
        {
            GameObject.Destroy(child.gameObject);
        }

        // instantiate the object links
        // GameObject go_links = (GameObject)Instantiate(equipPrefab_links, position, Quaternion.identity);
        Instantiate(equipPrefab_links, parent_links);

        // instantiate the object rechts
        // GameObject go_rechts = (GameObject)Instantiate(equipPrefab_rechts, position, Quaternion.identity);
        Instantiate(equipPrefab_rechts, parent_rechts);
    }
}