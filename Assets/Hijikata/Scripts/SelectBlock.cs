using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBlock : MonoBehaviour
{
    [SerializeField,Tooltip("Fire1かFire2をあてる")] string _buttonName = default;
    [SerializeField,Tooltip("床につけたTagの名前を入力")] string _tagName = default;

    [SerializeField,Tooltip("rayを飛んでいく飛距離")] float _distance = 10f;

    private void Update()
    {
        if(Input.GetButtonDown(_buttonName))
        {
            Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit _hit;
            Debug.DrawRay(_ray.origin, _ray.direction * _distance, Color.red, 5.0f); //実行中にSceneのほうを確認するとrayが飛んでいるのを確認できます.

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
