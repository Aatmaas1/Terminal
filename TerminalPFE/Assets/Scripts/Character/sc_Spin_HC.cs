using UnityEngine;

public class sc_Spin_HC : MonoBehaviour
{
    public float forceX, forceY, forceZ;
    float offset;


    private void Start()
    {
        offset = Random.Range(-1f, 1f);
    }

    void Update()
    {
        transform.RotateAround(transform.position, transform.right, forceX * Time.deltaTime * (Mathf.Pow(Mathf.Sin(Time.time+offset), 2) + 1));
        transform.RotateAround(transform.position, transform.up, forceY * Time.deltaTime * (Mathf.Pow(Mathf.Sin(Time.time+offset), 2) + 1));
        transform.RotateAround(transform.position, transform.forward, forceZ * Time.deltaTime * (Mathf.Pow(Mathf.Sin(Time.time+offset), 2) + 1));
    }
}
