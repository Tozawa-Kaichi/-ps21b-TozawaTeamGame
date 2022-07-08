using UnityEngine;
// Photon �p�̖��O��Ԃ��Q�Ƃ���
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;

/// <summary>
/// ���������玀�ʃI�u�W�F�N�g
/// </summary>
[RequireComponent(typeof(PhotonView), typeof(Collider))]
public class KillZone : MonoBehaviour
{
    PhotonView _view;

    private void Start()
    {
        _view = GetComponent<PhotonView>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        // �I�[�i�[���Ŕ��肷��
        if (collision.tag == "Player" && _view.IsMine)
        {
            // �N���ڐG�������𔻒肵�A�C�x���g�ʒm����
            int actorNum = collision.GetComponent<PhotonView>().OwnerActorNr;
            Debug.Log($"KillZone caught player {actorNum}");
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions();
            raiseEventOptions.Receivers = ReceiverGroup.All;
            SendOptions sendOptions = new SendOptions();
            PhotonNetwork.RaiseEvent(2, actorNum, raiseEventOptions, sendOptions);
        }
    }
}