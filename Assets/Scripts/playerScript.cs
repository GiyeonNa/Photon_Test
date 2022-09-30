using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class playerScript : MonoBehaviourPunCallbacks
{
    public PhotonView PV;

    private void Update()
    {
        if (PV.IsMine)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * Time.deltaTime * 7,
                                            Input.GetAxisRaw("Vertical") * Time.deltaTime * 7, 0));
        }
    }
}