using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;

[RequireComponent(typeof(Rigidbody), typeof(PhotonView))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float _power = 10f;
    Rigidbody _rb;
    PhotonView _view;
    Vector3 _input;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _view = GetComponent<PhotonView>();

        // プレイヤーからゲームを初期化する（本当はそうしない方がよい）
        if (PhotonNetwork.IsMasterClient)
        {
            GameObject go = GameObject.FindGameObjectWithTag("GameController");
            go.GetComponent<GameManager>().InitializeGame();
        }
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        _input = new Vector3(h, 0, v);

        if (_input != Vector3.zero)
        {
            this.transform.forward = _input;
        }
    }

    private void FixedUpdate()
    {
        _input = Camera.main.transform.TransformDirection(_input);
        _input.y = 0;

        if (_input != Vector3.zero)
        {
            _rb.AddForce(_input.normalized * _power);
            this.transform.forward = _rb.velocity;
        }
    }
}
