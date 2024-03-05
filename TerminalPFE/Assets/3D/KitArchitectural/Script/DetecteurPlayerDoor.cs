using UnityEngine;

public class DetecteurPlayerDoor : MonoBehaviour
{
    private UnityEventPortes UnityEventPortes;

    bool canDetect = true;

    private void Start()
    {
        UnityEventPortes = GetComponentInParent<UnityEventPortes>();
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canDetect)
        {
            //print("La porte " + transform.parent.name + " détecte " + other.name);
            UnityEventPortes.InteractDoorAutomatique();
            canDetect = false;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //print("La porte détecte le player en sortie" + transform.parent.name);
            UnityEventPortes.InteractDoorAutomatique();
            canDetect = true;
        }
    }

}
