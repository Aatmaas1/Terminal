using UnityEngine;

public class sc_FollowTarget_HC : MonoBehaviour
{
    public Transform Target;
    public float speed, multEffetDistance;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Target.position, speed * Time.deltaTime + Mathf.Pow(2 + Vector3.Distance(transform.position, Target.position), 2) * Time.deltaTime * multEffetDistance);
    }
}
