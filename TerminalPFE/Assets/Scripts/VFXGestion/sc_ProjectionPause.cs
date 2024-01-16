using UnityEngine;
using UnityEngine.VFX;

public class sc_ProjectionPause : MonoBehaviour
{
    public VisualEffect projectionFX;

    private bool isPause;
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
        if(isPause)
        {
            isPause = false;
            projectionFX.enabled = false;
        }
        else
        {
            isPause = true;
            projectionFX.enabled = true;
        }
    }
}
