using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	
	void Update () 
	{
		// þetta er eitthvað sem er í roll-a-ball. Gleymdi að taka þetta út.
		transform.Rotate (new Vector3 (0, 30, 0) * Time.deltaTime);
	}
}	
