using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	    void Update () 
    {
        transform.Rotate (new Vector2 (0, 180) * Time.deltaTime);
    }
}
