using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourChange : MonoBehaviour {
	public void ChangeColour() {
		GameObject.Find("ShoeManager").GetComponent<ShoeMenu>().ChangeColour(this.GetComponent<Image>().color);
		GameObject.FindGameObjectWithTag("ProductInfo").GetComponent<ProductInformation>().shoeColour.text = "KLEUR: " + this.transform.name.ToUpper();
	}
}
