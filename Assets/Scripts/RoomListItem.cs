using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;

public class RoomListItem : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    RoomInfo roomInfo;
    public void SetUp(RoomInfo info)
    {
        roomInfo = info;
        text.text = info.Name;
    }

    public void OnClick()
    {
        Launcher.Instance.JoinRoom(roomInfo);
    }
}
