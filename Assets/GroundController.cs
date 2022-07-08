using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;

[RequireComponent(typeof(PhotonView))]
public class GroundController : MonoBehaviour
{
    [SerializeField] float _limitTime = 2f;
    float _timer;
    PhotonView _view;
    Material _mat;
    bool _isTimerWorking = false;

    void Start()
    {
        _view = GetComponent<PhotonView>();
        Renderer r = GetComponent<MeshRenderer>();
        _mat = r.material;
        _timer = _limitTime;
    }

    private void FixedUpdate()
    {
        // 複数のプレイヤーが乗ったり降りたりした時に問題がある。
        if (_isTimerWorking)
        {
            _timer -= Time.fixedDeltaTime;

            if (_timer < 0)
            {
                if (_view.IsMine)
                {
                    PhotonNetwork.Destroy(_view);
                }
            }

            Color c = _mat.color;
            c.a = _timer / _limitTime;
            _mat.color = c;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _isTimerWorking = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _isTimerWorking = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _isTimerWorking = true;
        }
    }
}
