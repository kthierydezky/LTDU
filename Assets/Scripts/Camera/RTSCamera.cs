using UnityEngine;
using System.Collections;

public class RTSCamera : MonoBehaviour {
    public GameObject cameraGO;
    public float horizontalSpeed = 40f;
    public float verticalSpeed = 40f;
    public float mouseHorizontalSpeed = 1f;
    public float mouseVerticalSpeed = 1f;
    public float borderHorizontalSpeed = 0.5f;
    public float borderVerticalSpeed = 0.5f;
    public float cameraRotateSpeed = 80f;
    public float cameraDistance = 30f;
    public float borderPercentage = 0.025f;
    public float wheelSpeed = 60f;

    public Vector2 xMapLimit = new Vector2(-65f,65f);
    public Vector2 yMapLimit = new Vector2(-60f, 35f);
    public Vector2 zMapLimit = new Vector2(1f, 20f);
    public Vector2 cameraAngleLimit = new Vector3(30f, 75f);

    Vector2 curMousePosition = Vector2.zero;
    bool firstPushWheelClick = true;
    float curDistance;
	
	// Update is called once per frame
	void Update () {
        //déplacement clavier
        float horizontal = Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * verticalSpeed * Time.deltaTime;     
        transform.Translate(new Vector3(horizontal, 0,vertical));


        //Deplacement click molette
        if (Input.GetMouseButton(2))
        {
            if(firstPushWheelClick)
            {
                curMousePosition = (Vector2) Input.mousePosition;
                firstPushWheelClick = false;
            }
            Vector2 deltaMouse = curMousePosition - (Vector2) Input.mousePosition;
            transform.Translate(new Vector3(deltaMouse.x* mouseHorizontalSpeed * Time.deltaTime, 0, deltaMouse.y * mouseVerticalSpeed * Time.deltaTime));   
            curMousePosition = (Vector2)Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(2))
        {
            firstPushWheelClick = true;
        }

        //deplacement bord de l'ecran
        Rect screenRect = new Rect(0, 0, Screen.width, Screen.height);
        if (screenRect.Contains(Input.mousePosition))
        {
            float horizontalScreenBorder = Screen.width * borderPercentage;
            float verticalScreenBorder = Screen.height * borderPercentage;
            
            if (Input.mousePosition.x <= horizontalScreenBorder && Input.mousePosition.x > 0.0f)
            {
                horizontal = -borderHorizontalSpeed * horizontalSpeed * Time.deltaTime;
            }
            if (Input.mousePosition.x >= Screen.width - horizontalScreenBorder)
            {
                horizontal = borderHorizontalSpeed * horizontalSpeed * Time.deltaTime;
            }
            if (Input.mousePosition.y <= verticalScreenBorder && Input.mousePosition.y > 0.0f)
            {
                vertical = -borderHorizontalSpeed * verticalSpeed * Time.deltaTime;
            }
            if (Input.mousePosition.y >= Screen.height - verticalScreenBorder)
            {
                vertical = borderVerticalSpeed * verticalSpeed * Time.deltaTime;
            }

            transform.Translate(new Vector3(horizontal, 0, vertical));
        }

        //border limit
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, xMapLimit.x, xMapLimit.y), transform.position.y, Mathf.Clamp(transform.position.z, yMapLimit.x, yMapLimit.y));

        //Zoom
        if(Input.mouseScrollDelta != Vector2.zero)
        {
            cameraGO.transform.Translate(new Vector3(0.0f, -Input.mouseScrollDelta.y * wheelSpeed * Time.deltaTime, 0.0f) );
            cameraGO.transform.localPosition = new Vector3(0.0f, Mathf.Clamp(cameraGO.transform.position.y, zMapLimit.x, zMapLimit.y), 0.0f);
        }
        //Camera Orientation
        float calc = (cameraGO.transform.position.y - zMapLimit.x) / (zMapLimit.y - zMapLimit.x);
        float cAngle = (calc * (cameraAngleLimit.y - cameraAngleLimit.x)) + cameraAngleLimit.x;
        cameraGO.transform.localEulerAngles = new Vector3(cAngle, 0f, 0f);
    }
}
