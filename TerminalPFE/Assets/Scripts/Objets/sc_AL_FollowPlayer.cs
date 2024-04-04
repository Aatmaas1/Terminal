using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_AL_FollowPlayer : MonoBehaviour
{

    public GameObject Target;
  public float speed;

    // Update is called once per frame
    void Update()
    {
        // en move toward
        //this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, Target.transform.position, speed);
        // en Lerp
        this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, Target.transform.position, speed);

    }
}
