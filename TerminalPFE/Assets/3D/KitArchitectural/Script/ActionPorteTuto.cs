using UnityEngine;

public class ActionPorteTuto : MonoBehaviour
{
    //� passer en private
    public bool isOpening;
    private Animator PorteTutoAnimator;
    private void Start()
    {
        PorteTutoAnimator = GetComponent<Animator>();
    }

    public void PorteOpeningAndClosing()
    {
        if (isOpening)
        {
            //print("Je suis rentr� dans le Unity Event et je me ferme");

            PorteTutoAnimator.SetBool("IsOpening", false);
            
            isOpening = false;

            
        }
        
        else
        {
            //print("Je suis rentr� dans le Unity Event et je m'ouvre");
            PorteTutoAnimator.SetBool("IsOpening", true);
            
            isOpening = true;
        }
        
    }

    public void PorteOpeningBouton()
    {
        PorteTutoAnimator.SetTrigger("IsOpening");
    }

  

}
