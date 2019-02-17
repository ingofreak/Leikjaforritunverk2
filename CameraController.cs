using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	
	public GameObject player;

    public float rotateSpeed = 5;

    
    private Vector3 offset;

	
	void Start ()
	{
		
		offset = transform.position - player.transform.position;
	}

	
	void LateUpdate ()
	{
		
	//nota þennan kóða til að hreyfa myndavélinna með músinni
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        player.transform.Rotate(0, horizontal, 0);

        float desiredAngle = player.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(-90, desiredAngle, 0);
        transform.position = player.transform.position - (rotation * offset);

        transform.LookAt(player.transform);
    }
}
