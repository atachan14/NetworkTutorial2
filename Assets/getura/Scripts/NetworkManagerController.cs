using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkManagerController : MonoBehaviour
{
    void OnGUI()
    {
        if (!NetworkManager.Singleton.IsServer && !NetworkManager.Singleton.IsClient)
        {
            // サーバー開始ボタン
            if (GUILayout.Button("Start Server"))
            {
                NetworkManager.Singleton.StartServer();
            }

            // クライアント開始ボタン
            if (GUILayout.Button("Start Client"))
            {
                NetworkManager.Singleton.StartClient();
            }

            // ホスト開始ボタン
            if (GUILayout.Button("Start Host"))
            {
                NetworkManager.Singleton.StartHost();
            }
        }
        else
        {
            GUILayout.Label($"Connection Status: {(NetworkManager.Singleton.IsServer ? "Server" : "Client")}");
            GUILayout.Label($"Connected Clients: {NetworkManager.Singleton.ConnectedClients.Count}");
        }
    }
}