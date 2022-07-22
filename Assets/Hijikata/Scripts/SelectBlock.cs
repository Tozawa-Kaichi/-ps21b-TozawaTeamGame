using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBlock : MonoBehaviour
{
    [SerializeField,Tooltip("Fire1��Fire2�����Ă�")] string _buttonName = default;
    [SerializeField,Tooltip("���ɂ���Tag�̖��O�����")] string _tagName = default;

    [SerializeField,Tooltip("ray����ł����򋗗�")] float _distance = 10f;

    private void Update()
    {
        if(Input.GetButtonDown(_buttonName))
        {
            Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit _hit;
            Debug.DrawRay(_ray.origin, _ray.direction * _distance, Color.red, 5.0f); //���s����Scene�̂ق����m�F�����ray�����ł���̂��m�F�ł��܂�.

            if (Physics.Raycast(_ray, out _hit, _distance))
            {
                if(_hit.collider.CompareTag(_tagName))
                {
                    Debug.Log("yes");
                    Destroy(_hit.collider.gameObject);
                }
                else
                {
                    Debug.Log("no");
                }
            }
        }
    }

}
