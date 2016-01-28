using UnityEngine;
using System.Collections;

public class CameraPlayer_Link : MonoBehaviour {

    public Vector2 cameraSize;

    public Vector2 horizontalWorldBounds;
    public Vector2 verticalWorldBounds;

    public GameObject player;

    // Use this for initialization
    private void Start() 
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
		
    }
 
    // Update is called once per frame
    void Update () 
    {
        float deltaX = player.transform.position.x - transform.position.x;
        deltaX = (Mathf.Abs(deltaX) > cameraSize.x) ? (Mathf.Abs(deltaX) - cameraSize.x) * Mathf.Abs(deltaX) / deltaX : 0;

        float deltaY = player.transform.position.y - transform.position.y;
        deltaY = (Mathf.Abs(deltaY) > cameraSize.y) ? (Mathf.Abs(deltaY) - cameraSize.y) * Mathf.Abs(deltaY) / deltaY : 0;

        float width = CalculateGameWorldWidth();
        float newX = Mathf.Clamp(transform.position.x + deltaX, horizontalWorldBounds.x + 0.5f * width, horizontalWorldBounds.y - 0.5f * width);
        float newY = Mathf.Clamp(transform.position.y + deltaY, verticalWorldBounds.x + 0.5f * width, verticalWorldBounds.y - 0.5f * GetComponent<Camera>().orthographicSize);
        transform.position = new Vector3(newX, newY, transform.position.z);
    }

    private float CalculateGameWorldWidth()
    {
        return (GetComponent<Camera>().pixelWidth / GetComponent<Camera>().pixelHeight) * GetComponent<Camera>().orthographicSize;
    }
}