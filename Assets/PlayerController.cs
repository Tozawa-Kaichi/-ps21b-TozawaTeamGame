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
    Rigidbody _rb;
    PhotonView _view;
    Vector3 _input;

    public Animation _anim;
    public GameObject _particleObject;
    [SerializeField]
    private bool _isGround;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _view = GetComponent<PhotonView>();
        _anim = GetComponent<Animation>();

        // �v���C���[����Q�[��������������i�{���͂������Ȃ������悢�j
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
        if (Input.GetButtonDown("Jump"))
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
            _rb.AddForce(_input.normalized * _power);
            this.transform.forward = _rb.velocity;
        }
    }

    void BreakFloor()
    {
       _anim.Play();
        Instantiate(_particleObject, this.transform.position, Quaternion.identity);
    }

    void Jump()
    {
        _isGround = false;
        _rb.AddForce(new Vector3(0, _jumpPower, 0));
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "ground")
        {
            _isGround = true;
        }
    }
}
