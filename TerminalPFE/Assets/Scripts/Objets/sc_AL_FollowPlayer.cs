using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_AL_FollowPlayer : MonoBehaviour
{

    public GameObject Target;
    public float speed, hauteur;

    public Transform center;

    public LayerMask mask;
    RaycastHit _hit;

    // Update is called once per frame
    void Update()
    {
        // en move toward
        //this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, Target.transform.position, speed);
        // en Lerp
        this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, Target.transform.position, speed);

        if(Physics.Raycast(center.position, -transform.up, out _hit, 5f, mask))
        {
            float ySable = _hit.point.y + hauteur;
            Vector3 pos = new Vector3(this.transform.position.x, ySable, this.transform.position.z);

            this.transform.position = pos;
        }

    }
}
