using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	private PlayerController player;
	
	void Start(){
		player = gameObject.GetComponentInParent<PlayerController>();
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (!player.groundmode) {
			player.groundmode = true;
			player.JetOff();
			}
		player.grounded = true;
		player.jumping = false;
		player.jetsready = false;
		}
	void OnTriggerExit2D(Collider2D col)
	{
		player.grounded = false;
	}
	
	void OnTriggerStay2D(Collider2D col) {
		player.grounded = true;
	}
	
}
