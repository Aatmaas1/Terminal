using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class sc_Anim_AvatarVirtuel_HC : MonoBehaviour
{
    #region Variables

    public GameObject[] Membres;
    public GameObject[] refs;
    public float[] rotations;

    [SerializeField]
    bool _isMoving = false;

    StarterAssetsInputs _refMouvement;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _refMouvement = transform.parent.GetComponent<StarterAssets.StarterAssetsInputs>();
        SwitchToIdle();
    }

    // Update is called once per frame
    void Update()
    {
        if(_refMouvement.move == Vector2.zero)
        {
            if (_isMoving) { SwitchToIdle(); }
            _isMoving = false;
        }
        else
        {
            if (!_isMoving) { SwitchToMove(); }
            _isMoving = true;
        }
    }

    private void FixedUpdate()
    {
        if (_isMoving)
        {
            for (int i = 0; i < Membres.Length; i++)
            {
                Membres[i].transform.position = new Vector3(Membres[i].transform.position.x, Mathf.Cos(-Time.time * 4 + 45*i)*Time.fixedDeltaTime*7 + 0.15f + transform.parent.position.y, Membres[i].transform.position.z);
            }
        }
        else
        {
            for (int i = 0; i < Membres.Length; i++)
            {
                refs[i].transform.Rotate(transform.up, rotations[i]*Time.fixedDeltaTime);
            }
        }
    }

    public void SwitchToIdle()
    {
        for(int i = 0; i < Membres.Length; i++)
        {
            Membres[i].transform.position = new Vector3(Mathf.Sin(90 * i)*0.1f, 0.04f * i+0.1f, Mathf.Cos(90 * i)*0.1f) + transform.position;
        }
    }

    public void SwitchToMove()
    {
        for (int i = 0; i < Membres.Length; i++)
        {
            Membres[i].transform.position = transform.position + transform.forward * -(-0.4f + 0.18f*i);
        }
    }
}
