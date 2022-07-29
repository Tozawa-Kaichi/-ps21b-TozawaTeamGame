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
    [SerializeField] float _jumpPower = 10f;
    [SerializeField] float _dushPower = 2f;
    Rigidbody _rb;
    PhotonView _view;
    Vector3 _input;

    //public Animation _anim;
    //public GameObject _particleObject;
    [SerializeField]
    private bool _isGround;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _view = GetComponent<PhotonView>();
        //_anim = GetComponent<Animation>();

        // プレイヤーからゲームを初期化する（本当はそうしない方がよい）
        if (PhotonNetwork.IsMasterClient)
        {
            GameObject go = GameObject.FindGameObjectWithTag("GameController");
            go.GetComponent<GameManager>().InitializeGame();
        }
    }

    void Update()
    {
        if (!_view.IsMine) return;
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
        _input = new Vector3(h, 0, v);
        if (Input.GetButtonDown("Fire1"))
        {
            BreakFloor();
        }
        if (Input.GetButtonDown("Jump")&&_isGround)
        {
            Debug.Log("jump");
            Jump();
        }
    }

    private void FixedUpdate()
    {
        _input = Camera.main.transform.TransformDirection(_input);
        _input.y = 0;

        if (_input != Vector3.zero)
        {
            if (Input.GetButton("Fire1"))
            {
                _rb.AddForce(_input.normalized * _power * _dushPower);
                this.transform.forward = _rb.velocity;
                Debug.Log("Dush");
            }
            else
            {
                _rb.AddForce(_input.normalized * _power);
                this.transform.forward = _rb.velocity;
            }
        }
    }

    void BreakFloor()
    {
       //_anim.Play();
        //Instantiate(_particleObject, this.transform.position, Quaternion.identity);
    }

    void Jump()
    {
        _rb.AddForce(new Vector3(0, _jumpPower, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "floor")
        {
            _isGround = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _isGround = false;
    }
}
