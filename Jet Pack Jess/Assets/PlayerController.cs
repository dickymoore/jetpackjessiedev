using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 1.0f;
	public float jetspeed = 10.0f;
	public float JumpPower = 20.0f;
	public bool grounded = true;
	public bool groundmode = true;
	public bool jumping = false;
	public bool jetsready = false;
	public float maxSpeed = 3.0f;
	public int FuelLevel = 0;
		
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("FuelCache")) {
		other.gameObject.SetActive(false);
		
		}
	}
	void FixedUpdate () {
		if (groundmode) {
		GroundMovement();
		} else {
			JetPackMovement();
			}
	}
	
	void GroundMovement() {
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");
        
        if (x > 0f) {
			transform.position += new Vector3 (speed*Time.deltaTime, 0.0f, 0.0f);
		}
		if (x < 0f) {
			transform.position -= new Vector3 (speed*Time.deltaTime, 0.0f, 0.0f);
		}
		
		
		if (y > 0f) {
			if (grounded) {
				Jump();
				} else {
					if (jetsready) {
					StartJetPack();
				}}
			}
		if (!grounded) {
			if (y < 1f) {
				jetsready = true;
			}
			if (y> 0f && jetsready) {
				StartJetPack();
			}
		}
		}
		
	void JetPackMovement() {
		float x = Input.GetAxis ("Horizontal");
        float y = Input.GetAxis ("Vertical");

        Vector2 movement = new Vector3 (x, y);
        rb2d.AddForce (movement * jetspeed);
		if (rb2d.velocity.x > maxSpeed) {
			rb2d.velocity = new Vector2 (maxSpeed, rb2d.velocity.y);
		}
		if (rb2d.velocity.x < -maxSpeed) {
			rb2d.velocity = new Vector2 (-maxSpeed, rb2d.velocity.y);
		}
	}
		
		
	void Jump () {
		jumping = true;
		Vector2 jumpmove = new Vector2 (0.0f, 1f);
		rb2d.AddForce(jumpmove * JumpPower);
	}
	void StartJetPack() {
		groundmode = false;
		JetOn();
	}
	
	
	public void JetOn() {
		gameObject.GetComponent<Renderer>().material.color = new Color(100,0,0,0f);
	}
	public void JetOff() {
				gameObject.GetComponent<Renderer>().material.color = new Color(0f,0,0,0f);
	}
	
}

