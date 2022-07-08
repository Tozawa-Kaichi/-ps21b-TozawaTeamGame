using System.Linq;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

/// <summary>
/// �Q�[�����Ǘ�����R���|�[�l���g
/// �C�x���g�R�[�h 2 �� Kill �Ƃ���
/// </summary>
public class GameManager : MonoBehaviourPunCallbacks, IOnEventCallback
{
    [SerializeField] string _blockPrefabName = "BlockPrefab";
    [SerializeField] Transform _blockAnchorRoot;

    public void InitializeGame()
    {
        foreach(var a in _blockAnchorRoot.GetComponentsInChildren<Transform>())
        {
            PhotonNetwork.Instantiate(_blockPrefabName, a.position, Quaternion.identity);
        }
    }

    void IOnEventCallback.OnEvent(EventData photonEvent)
    {
        // ���ꂽ�C�x���g�� 2 �Ƃ���
        if (photonEvent.Code == 2)
        {
            int killedPlayerActorNumber = (int)photonEvent.CustomData;
            print($"Player {photonEvent.Sender} retired.");

            // ���ꂽ�̂������������玩��������
            if (killedPlayerActorNumber == PhotonNetwork.LocalPlayer.ActorNumber)
            {
                GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
                GameObject me = players.Where(x => x.GetPhotonView().IsMine).FirstOrDefault();
                PhotonView view = me.GetPhotonView();
                PhotonNetwork.Destroy(view);
            }
        }
    }
}