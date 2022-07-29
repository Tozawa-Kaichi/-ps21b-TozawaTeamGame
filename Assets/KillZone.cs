using UnityEngine;
// Photon 用の名前空間を参照する
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;

/// <summary>
/// 当たったら死ぬオブジェクト
/// </summary>
[RequireComponent(typeof(Collider))]
public class KillZone : MonoBehaviour
{
    PhotonView _view;

    private void Start()
    {
        _view = GetComponent<PhotonView>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        // MasterClient で判定する
        if (collision.tag == "Player" && PhotonNetwork.IsMasterClient)
        {
            // 誰が接触したかを判定し、イベント通知する
            int actorNum = collision.GetComponent<PhotonView>().OwnerActorNr;
            Debug.Log($"KillZone caught player {actorNum}");
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions();
            raiseEventOptions.Receivers = ReceiverGroup.All;
            SendOptions sendOptions = new SendOptions();
            PhotonNetwork.RaiseEvent(1, actorNum, raiseEventOptions, sendOptions);
        }
    }
}