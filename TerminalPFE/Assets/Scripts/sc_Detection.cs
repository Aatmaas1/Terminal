using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class sc_Detection : MonoBehaviour
{

    public VisualEffect detectionFX;

    public List<VisualEffect> interractableList;

    public bool onDetection;

    public Transform player;

    public bool haveLife;
    public int life;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (onDetection)
        {
            foreach (VisualEffect fx in interractableList)
            {
                fx.SetVector3("PlayerPos", player.position);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (haveLife)
            {
                if (life > 0)
                {
                    life--;
                    sc_ScreenShake.instance.OnInteractPlayerLight();
                    sc_ScreenShake.instance.FovBase();
                    player = other.transform;

                    detectionFX.transform.position = other.transform.position;
                    detectionFX.SendEvent("OnDetection");

                    onDetection = true;

                    foreach (VisualEffect fx in interractableList)
                    {
                        fx.enabled = true;

                    }
                }
            }
            else
            {
                sc_ScreenShake.instance.OnInteractPlayerLight();

                player = other.transform;

                detectionFX.transform.position = other.transform.position;
                detectionFX.SendEvent("OnDetection");

                onDetection = true;

                foreach (VisualEffect fx in interractableList)
                {
                    fx.enabled = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            player = null;

            onDetection = false;

            foreach (VisualEffect fx in interractableList)
            {
                fx.enabled = false;

            }

        }
    }

}
