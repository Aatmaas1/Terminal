using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class sc_TextAnimation_TV : MonoBehaviour
{
    public TextMeshProUGUI textcomponent;

    public AK_POSTEVENT_AM randomSound;

    public string[] lignes;
    public string[] lignes2;
    public string[] lignes3;



    public List<string[]> page = new List<string[]>();
    public float speedChar;
    public float speedLigne;
    public float speedAttenteDansTexte;

    private int index;
    private int pageindex;


    private char retourligne = 'ù';
    private char AttenteDansTexte = '§';
    private char effacerCharMoinsUn = '°';

    public void Start()
    {
        page.Add(lignes); page.Add(lignes2); page.Add(lignes3);
        pageindex = 0;
        index = 0;

    }
    public void OnEnable()
    {
        textcomponent.text = string.Empty;
        StartAffichage();
    }

    public void StartAffichage()
    {
        index = 0;
        StartCoroutine(TypeLigne(page[pageindex]));

    }

    IEnumerator TypeLigne(string[] Lignes)
    {

        foreach (char c in Lignes[index].ToCharArray())
        {
            if (c == retourligne)
            {
                randomSound.PostEvent();
                textcomponent.text += "<br>";
                yield return new WaitForSecondsRealtime(speedLigne);
            }
            else if (c == AttenteDansTexte)
            {
                randomSound.PostEvent();
                yield return new WaitForSecondsRealtime(speedAttenteDansTexte);
            }
            else if (c == effacerCharMoinsUn)
            {
                randomSound.PostEvent();
                textcomponent.text = textcomponent.text.Substring(0, textcomponent.text.Length - 1);
            }
            else
            {
                randomSound.PostEvent();
                textcomponent.text += c;
                yield return new WaitForSecondsRealtime(speedChar);
            }



        }
        NextLignes(Lignes);

    }
    void NextLignes(string[] Lignes)
    {
        if (index < Lignes.Length - 1)
        {
            index++;

            StartCoroutine(TypeLigne(page[pageindex]));

        }
        else
        {
            ClearConsole();

        }
    }
    void ClearConsole()
    {
        if (pageindex < page.Count)

            textcomponent.text = string.Empty;
        pageindex++;
        index = 0;

        print(" page index = " + pageindex);

        StartCoroutine(TypeLigne(page[pageindex]));


    }


}
