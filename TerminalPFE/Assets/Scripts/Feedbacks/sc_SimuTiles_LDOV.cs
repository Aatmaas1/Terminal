using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_SimuTiles_LDOV : MonoBehaviour
{
    private Material _mat;

    public bool _touch;

    float _clrChangr = 0;

    public float changerSpeed;

    public int idBox;

    // Start is called before the first frame update
    void Start()
    {
        _mat = GetComponentInParent<MeshRenderer>().material;
    }


    // Update is called once per frame
    void Update()
    {
        if(_touch)
        {
            _clrChangr = Mathf.MoveTowards(_clrChangr, 2, changerSpeed * Time.deltaTime);

            _mat.SetFloat("_ColorChanger", _clrChangr); ;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _touch = true; 
            //print("playerDetection");
            _mat.SetVector("_PlayerPos", other.transform.position);
            //gameObject.GetComponentInChildren<ParticleSystem>().Play();
        }
    }

    public void StartTrigger()
    {
        //Debug.Log("aaaaaaa");
        _mat = GetComponentInParent<MeshRenderer>().material;
        _touch = true;
        _mat.SetVector("_PlayerPos", transform.position + Vector3.up);
        //gameObject.GetComponentInChildren<ParticleSystem>().Play();
    }

}
