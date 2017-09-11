using UnityEngine;

public class CameraController : MonoBehaviour {

    private bool doMovement = true;

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;
    public float minX = 7.46f;
    public float maxX = 67.46f;
    public float minZ = -20f;
    public float maxZ = 55f;

    Vector3 initialRotation;

    private void Start()
    {
        initialRotation = transform.eulerAngles;
    }

    private void Update()
    {

        if(GameManager.gameIsOver)
        {
            this.enabled = false;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            doMovement = !doMovement;
        }
            
        if (!doMovement)
        {
            return;
        }            

        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow) || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow) || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow) || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow) || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 500 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);

        transform.position = pos;

        Vector3 rot = transform.eulerAngles;

        rot.x = initialRotation.x - (80 - pos.y) / 2;

        transform.eulerAngles = rot;
    }

}
