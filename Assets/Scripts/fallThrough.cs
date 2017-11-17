using UnityEngine;
using System.Collections;

public class fallThrough : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		Physics2D.IgnoreLayerCollision (LayerMask.NameToLayer("Shootable"), LayerMask.NameToLayer("Shootable"));	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
