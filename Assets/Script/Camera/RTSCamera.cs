using UnityEngine;
using System.Collections;

public class RTSCamera : MonoBehaviour {

    public float horizontalSpeed = 40f;
    public float verticalSpeed = 40f;
    public float cameraRotateSpeed = 80f;
    public float cameraDistance = 30f;

    float curDistance;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * verticalSpeed * Time.deltaTime;
        float rotation = Input.GetAxis("Rotation");

        transform.Translate(new Vector3(horizontal, 0,vertical));

        if (rotation !=0)
        {
            transform.Rotate(Vector3.up * cameraRotateSpeed * Time.deltaTime,Space.World);
        }
        //transform.Translate(Vector3.right * );
    }
}
