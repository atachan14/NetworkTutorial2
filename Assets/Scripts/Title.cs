using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartHost()
    {
        NetworkManager.Singleton.ConnectionApprovalCallback = ApprovalCheck;

        //ホスト開始
        NetworkManager.Singleton.StartHost();

        //シーン切り替え
        NetworkManager.Singleton.SceneManager.LoadScene("Game", LoadSceneMode.Single);

    }

    public void StartClient()
    {
        bool result = NetworkManager.Singleton.StartClient();
    }

    private void ApprovalCheck(NetworkManager.ConnectionApprovalRequest request
        , NetworkManager.ConnectionApprovalResponse response)
    {
        response.Pending = true;

        if (NetworkManager.Singleton.ConnectedClients.Count >= 4)
        {
            response.Approved = false;
            response.Pending = false;
            return;
        }

        response.Approved = true;

        response.CreatePlayerObject = true;

        response.PlayerPrefabHash = null;

        var position = new Vector3(0, 1, -8);
        position.x = -5 + 5 *
            (NetworkManager.Singleton.ConnectedClients.Count % 3);
        response.Position = position;

        response.Rotation = Quaternion.identity;

        response.Pending = false;
    }

}
