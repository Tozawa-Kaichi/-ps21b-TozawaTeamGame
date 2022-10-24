using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorVisible : MonoBehaviour
{
    [SerializeField,Tooltip("�J�[�\������ʂɂł邩�o�Ȃ���")] bool IsVisible = default;

    [SerializeField,Tooltip("�J�[�\���̉摜������B�Ȃ���΂Ȃɂ�����Ȃ��đ��v")] Texture2D _cursorTexture = default;
    Vector2 _hotSpot;
    CursorMode _cursorMode;

    void Start()
    {
        //�J�[�\���̕\��
        Cursor.visible = IsVisible;

        _hotSpot = Vector2.zero;
        _cursorMode = CursorMode.Auto;

        if(_cursorTexture == null)
        {
            _cursorTexture = null;
        }
        //�J�[�\���̉摜�̍����ւ�
        Cursor.SetCursor(_cursorTexture, _hotSpot, _cursorMode);
    }
}
