using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class sc_4nn4Text : MonoBehaviour
{
    private TextMeshProUGUI textcomponent;

    [SerializeField] string lignes;
    

    public float speedChar;
    
    public float speedAttenteDansTexte;

    
    private char AttenteDansTexte = 'ù';
    private char effacerCharMoinsUn = '°';

    public void Start()
    {
        textcomponent = gameObject.GetComponent<TextMeshProUGUI>();
    }
    public void OnEnable()
    {
        textcomponent.text = string.Empty;
        StartAffichage();
    }

    public void StartAffichage()
    {
        
        StartCoroutine(TypeLigne(lignes));

    }

    IEnumerator TypeLigne(string Lignes)
    {

        foreach (char c in Lignes)
        {
            
            if (c == AttenteDansTexte)
            {
                yield return new WaitForSecondsRealtime(speedAttenteDansTexte);
            }
            else if (c == effacerCharMoinsUn)
            {
                textcomponent.text = textcomponent.text.Substring(0, textcomponent.text.Length - 1);
            }
            else
            {
                
                textcomponent.text += c;
                yield return new WaitForSecondsRealtime(speedChar);
            }



        }
       

    }
   
}
