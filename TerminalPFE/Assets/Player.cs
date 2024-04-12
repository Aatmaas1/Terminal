using UnityEngine;

public class Player : MonoBehaviour
{
    private float basicSpeed;
    public float speed;
    public float maxSpeed;
    public float acceleration;

    public float jumpForce;

    public float sensitivity;

    public float magni;

    public GameObject camHolder;
    public Camera cam;
    public GameObject wave1;
    public GameObject wave2;

    private float horizontal;
    private float vertical;

    private float horCam;
    private float verCam;

    private Rigidbody rb;

    private float fov;
    private float maxFov;

    public bool landed;

    // Start is called before the first frame update
    void Start()
    {
        basicSpeed = speed;

        rb = GetComponent<Rigidbody>();

        fov = cam.fieldOfView;
        maxFov = fov * 2;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal") * 50;
        vertical = Input.GetAxis("Vertical") * 50;

        //horCam = Input.GetAxis("Mouse X") * sensitivity;
        //verCam = Input.GetAxis("Mouse Y") * sensitivity;

        //on avance + accelere
        if (horizontal != 0 || vertical != 0)
        {
            Vector3 velo = new Vector3(horizontal, rb.velocity.y, vertical) * speed * Time.deltaTime * 10f;

            rb.velocity = transform.TransformDirection(velo);

            speed = Mathf.MoveTowards(speed, maxSpeed, acceleration * Time.deltaTime);

            cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, maxFov, acceleration * Time.deltaTime);

            wave1.transform.localScale = Vector3.MoveTowards(wave1.transform.localScale, new Vector3(1, 1, 1), acceleration/15 * Time.deltaTime);
            wave2.transform.localScale = Vector3.MoveTowards(wave2.transform.localScale, new Vector3(1, 1, 1), acceleration/15 * Time.deltaTime);
        }

        //on relentis
        else
        {
            speed = Mathf.MoveTowards(speed, basicSpeed, acceleration * 2 * Time.deltaTime);
            cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, fov, acceleration * 2 * Time.deltaTime);

            wave1.transform.localScale = Vector3.MoveTowards(wave1.transform.localScale, new Vector3(0, 0, 0), acceleration/15*2  * Time.deltaTime);
            wave2.transform.localScale = Vector3.MoveTowards(wave2.transform.localScale, new Vector3(0, 0, 0), acceleration/15 *2* Time.deltaTime);
        }

        //magni = rb.velocity.magnitude;

        //jump
        //if (Input.GetKeyDown(KeyCode.Space) && landed)
        //{
        //    rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        //}
        //
        //if (landed != true)
        //{
        //    rb.mass = Mathf.MoveTowards(rb.mass, 25, 10 * Time.deltaTime);
        //}
        //else rb.mass = 1;

        //control de cam
        var c = camHolder.transform;
        transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);
        c.Rotate(-Input.GetAxis("Mouse Y") * sensitivity, 0, 0);
        c.Rotate(0, 0, -Input.GetAxis("QandE") * 90 * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Sol"))
        {
            landed = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Sol"))
        {
            landed = false;
        }
    }
}
