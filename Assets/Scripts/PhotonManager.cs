using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;


public class PhotonManager : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI statusText;
    public TMP_InputField nickNameInput;
    public TMP_InputField roomNameInput;
    public GameObject uiPanel;
    public byte userNum = 5;
    private bool connect = false;

    //���� ���� ǥ�� 
    private void Update() => statusText.text = PhotonNetwork.NetworkClientState.ToString();

    //������ ����
    public void Connect() => PhotonNetwork.ConnectUsingSettings();
    //���� �Ǹ� ȣ��
    public override void OnConnectedToMaster()
    {
        print("�������ӿϷ�");
        string nickName = PhotonNetwork.LocalPlayer.NickName;
        nickName = nickNameInput.text;
        print("����� �̸��� " + nickName + " �Դϴ�.");
        connect = true;
    }

    //���� ����
    public void Disconnect() => PhotonNetwork.Disconnect();
    //connect = false;

    //���� ������ �� ȣ��
    public override void OnDisconnected(DisconnectCause cause) => print("�������");

    //�� ����
    public void JoinRoom()
    {
        if (connect)
        {
            PhotonNetwork.JoinRandomRoom();
            uiPanel.SetActive(false);
            print(roomNameInput.text + "�濡 �����Ͽ����ϴ�.");
        }
    }

    //���� �� ���忡 �����ϸ� ���ο� �� ���� (master �� ����)
    public override void OnJoinRandomFailed(short returnCode, string message) =>
    PhotonNetwork.CreateRoom(roomNameInput.text, new RoomOptions { MaxPlayers = userNum });

    //�濡 ���� ���� �� ȣ�� 
    public override void OnJoinedRoom()
    => PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);

}
