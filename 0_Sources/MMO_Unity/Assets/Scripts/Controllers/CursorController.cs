using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    int _mask = (1 << (int)Define.Layer.Ground) | (1 << (int)Define.Layer.Monster);

    Texture2D _attackIcon;
    Texture2D _handIcon;
    Vector2 _attackPos;
    Vector2 _handPos;

    enum CursorType
    {
        None,
        Attack,
        Hand,
    }

    CursorType _cursorType = CursorType.None;

    void Start()
    {
        _attackIcon = Managers.Resource.Load<Texture2D>("Textures/Cursor/Attack");
        _attackPos = new Vector2(_attackIcon.width / 5, 0);
        _handIcon = Managers.Resource.Load<Texture2D>("Textures/Cursor/Hand");
        _handPos = new Vector2(_handIcon.width / 3, 0);
    }
    
    void Update()
    {
        if (Input.GetMouseButton(0))
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Camera.main.farClipPlane, _mask))
        {
            if (hit.collider.gameObject.layer == (int)Define.Layer.Monster)
            {
                if (_cursorType != CursorType.Attack)
                {
                    Cursor.SetCursor(_attackIcon, _attackPos, CursorMode.Auto);
                    _cursorType = CursorType.Attack;
                }

            }
            else
            {
                if (_cursorType != CursorType.Hand)
                {
                    Cursor.SetCursor(_handIcon, _handPos, CursorMode.Auto);
                    _cursorType = CursorType.Hand;
                }
            }
        }
    }
}
