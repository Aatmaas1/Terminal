using UnityEngine;

public class sc_ProjectionPause : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        sc_Test.instance.OnTamer += PauseProjo;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PauseProjo()
    {

    }
}
