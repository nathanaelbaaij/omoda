using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class SceneLoader : MonoBehaviour {

    public void LoadScene(string level)
    {

        SceneManager.LoadScene(level);
    }
}
