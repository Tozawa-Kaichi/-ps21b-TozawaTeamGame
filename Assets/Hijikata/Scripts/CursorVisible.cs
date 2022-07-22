using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorVisible : MonoBehaviour
{
    [SerializeField,Tooltip("カーソルが画面にでるか出ないか")] bool IsVisible = default;

    [SerializeField,Tooltip("カーソルの画像を入れる。なければなにもいれなくて大丈夫")] Texture2D _cursorTexture = default;
    Vector2 _hotSpot;
    CursorMode _cursorMode;

    void Start()
    {
        //カーソルの表示
        Cursor.visible = IsVisible;

        _hotSpot = Vector2.zero;
        _cursorMode = CursorMode.Auto;

        if(_cursorTexture == null)
        {
            _cursorTexture = null;
        }
        //カーソルの画像の差し替え
        Cursor.SetCursor(_cursorTexture, _hotSpot, _cursorMode);
    }
}
