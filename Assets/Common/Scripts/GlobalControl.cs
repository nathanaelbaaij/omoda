using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour {
	public static GlobalControl Instance;
	public Renderer[] shoeRChildren;
	public GameObject shoeR;

	void Awake() {
		if(Instance == null) {
			shoeR = GameObject.Find("Rechterschoen");
			shoeRChildren = shoeR.GetComponentsInChildren<Renderer>();
			GetChildren(shoeR.transform);

			DontDestroyOnLoad(gameObject);
			Instance = this;
		} else if(Instance != this) {
			Destroy(gameObject);
		}
	}

	private void GetChildren(Transform obj) {	
        foreach (Renderer child in shoeRChildren)
        {
			if(child.tag == "ColourChange") {
				child.material.color = Color.yellow;
			}
        }
	}
}
