using UnityEngine;

public class ActionPorteTuto : MonoBehaviour
{
    //� passer en private
    public bool isOpen;
    private Animator PorteTutoAnimator;
    private void Start()
    {
        PorteTutoAnimator = GetComponent<Animator>();
    }

    public void PorteOpeningAndClosing()
    {
        if (isOpen)
        {
            print("Je suis rentr� dans le Unity Event et je veux me fermer");

            PorteTutoAnimator.SetBool("IsOpening", false);
           
            isOpen = false;
        }
        else
        {
            print("Je suis rentr� dans le Unity Event et je veux m'ouvrir");
            PorteTutoAnimator.SetBool("IsOpening", true);
            
            isOpen = true;
        }
    }

  

}
