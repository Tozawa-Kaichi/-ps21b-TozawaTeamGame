using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using System.Collections.Generic;
using System.Collections;

/// <summary>
/// �Q�[�����Ǘ�����R���|�[�l���g
/// �C�x���g�R�[�h 1 �� Kill �Ƃ���
/// </summary>
public class GameManager : MonoBehaviourPunCallbacks, IOnEventCallback
{
    [SerializeField] string _blockPrefabName = "BlockPrefab";
    [SerializeField,Header("��")] Transform _blockAnchorRoot;
    [SerializeField] Text _message;
    public void InitializeGame()
    {
        foreach(var a in _blockAnchorRoot.GetComponentsInChildren<Transform>())
        {
            PhotonNetwork.Instantiate(_blockPrefabName, a.position, Quaternion.identity);
        }
    }


   /* private void FixedUpdate()
    {
        if (bool)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
                _timeText.text = time.ToString("F2") + "�b";
            }
            else if (time < 0)
            {
                timeUp = true;
            }
        }
    }*/



    void IOnEventCallback.OnEvent(EventData photonEvent)
    {
        // ���ꂽ�C�x���g�� 1 �Ƃ���
        if (photonEvent.Code == 1)
        {
            int killedPlayerActorNumber = (int)photonEvent.CustomData;
           /* string message = $"Player {killedPlayerActorNumber} retired.";
            print(message);
            if (_message)
            {
                _message.text = message;
            }*/
            // ���ꂽ�̂������������玩��������
            if (killedPlayerActorNumber == PhotonNetwork.LocalPlayer.ActorNumber)
            {
                GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
                GameObject me = players.Where(x => x.GetPhotonView().IsMine).FirstOrDefault();
                PhotonView view = me.GetPhotonView();
                PhotonNetwork.Destroy(view);
                if (killedPlayerActorNumber ==1)
                {
                    string loseMessage = $"Player {killedPlayerActorNumber} Lose!";
                    if (_message)
                    {
                        _message.text = loseMessage;
                    }
                }
                else if(killedPlayerActorNumber ==2)
                {
                    string loseMessage1 = $"Player {killedPlayerActorNumber} Lose!";
                    if (_message)
                    {
                        _message.text = loseMessage1;
                    }
                }
                else if(killedPlayerActorNumber ==1&&killedPlayerActorNumber==2)
                {
                    string DrawMessage = $"Player1 & 2 Draw!";
                    if (_message)
                    {
                        _message.text = DrawMessage;
                    }
                }
                TimerDecreseController.timeGroup = 2;
            }
            else if(killedPlayerActorNumber!= PhotonNetwork.LocalPlayer.ActorNumber)
            {
                GameObject go = GameObject.FindGameObjectWithTag("Player");
                go.TryGetComponent(out Rigidbody rb);
                if(killedPlayerActorNumber==1)
                {                   
                    string winMessage = $"Player {killedPlayerActorNumber+1} Win!";
                    if (_message)
                    {
                        _message.text = winMessage;
                    }
                }
                else if(killedPlayerActorNumber ==2)
                {
                    string winMessage1 = $"Player {killedPlayerActorNumber-1} Win!";
                    if (_message)
                    {
                        _message.text = winMessage1;
                    }
                }
                TimerDecreseController.timeGroup = 2;
                rb.isKinematic = true;
            }
        }
    }
}