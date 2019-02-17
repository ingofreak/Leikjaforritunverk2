using UnityEngine;


using UnityEngine.UI;

using System.Collections;

public class PlayerController : MonoBehaviour {
	
	
	public float speed;
	public Text countText;
	public Text winText;

	
	private Rigidbody rb;
	private int count;

    public bool isGrounded;

	
	void Start ()
	{
		
		rb = GetComponent<Rigidbody>();

		 
		count = 0;

		
		SetCountText ();

		
		winText.text = "";
	}

    void OnCollisionEnter(Collision col)
    {   //bara hægt að hoppa þegar þú ert á jörðinni
        if (col.gameObject.tag == ("Ground") && isGrounded == false)
        {
            isGrounded = true;
        }
    }

  .
    void FixedUpdate ()
	{
		//hreyfingar
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		
		rb.AddForce (movement * speed);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            isGrounded = false;
        }

    }

	
	void OnTriggerEnter(Collider other) 
	{
		
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			
			other.gameObject.SetActive (false);

			
			count = count + 1;

			
			SetCountText ();
		}
	}

	
	void SetCountText()
	{
		
		countText.text = "Peningar: " + count.ToString ();

		//ef þú nærð 5 peningum
		if (count >= 5) 
		{
			//game over skilaboð
			winText.text = "Þú Vinnur!";
		}
	}
}
