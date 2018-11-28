using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class SceneLoader : MonoBehaviour {

    public void LoadScene(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void BackButtonTrackingMenu()
    {
        // Remove old Shoemanager to prevent duplication
        GameObject shoeManager = GameObject.FindGameObjectWithTag("ShoeManager");
        Destroy(shoeManager);

        SceneManager.LoadScene("2-ShoeMenu");
    }
}
