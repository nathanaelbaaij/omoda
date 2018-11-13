using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class SceneLoader : MonoBehaviour {

    public void LoadScene(int level)
    {

        SceneManager.LoadScene(level);
    }
}
