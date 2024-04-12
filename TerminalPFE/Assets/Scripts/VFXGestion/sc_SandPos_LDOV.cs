using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_SandPos_LDOV : MonoBehaviour
{

    public Transform playerPos;
    public Vector2 clamp;

    Vector3 diffPos;

    // Start is called before the first frame update
    void Awake()
    {
        diffPos = new Vector3(transform.position.x - playerPos.position.x, transform.position.y - playerPos.position.y, transform.position.z - playerPos.position.z);
        print(playerPos.position.y + diffPos.y);
    }

    private void Start()
    {
        if(transform.parent != null)
        {
            transform.parent = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float ypos = playerPos.position.y + diffPos.y;
        ypos = Mathf.Clamp(ypos, clamp.x, clamp.y);
        Vector3 pos = new Vector3(playerPos.position.x + diffPos.x, ypos, playerPos.position.z + diffPos.z);
        transform.position = pos;
    }
}
