using UnityEngine;

public class sc_FollowTarget_HC : MonoBehaviour
{
    public Transform Target;
    public float speed, multEffetDistance;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.position, speed * Time.deltaTime
            + Mathf.Pow(Vector3.Distance(transform.position, Target.position), 3) * Time.deltaTime * multEffetDistance);
    }
}
