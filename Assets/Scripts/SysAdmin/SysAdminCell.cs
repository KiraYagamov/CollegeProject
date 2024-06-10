using DefaultNamespace;
using UnityEngine;

public class SysAdminCell : MonoBehaviour
{
    private WhatIsIt _whatIsIt;
    private int _rightPos;
    private int _currentPos;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Sprite[] sprites;
    public bool inited = false;
    
    public void Init(int rightPos, int startPos, WhatIsIt whatIsIt)
    {
        _rightPos = rightPos;
        _whatIsIt = whatIsIt;

        switch (whatIsIt)
        {
            case WhatIsIt.Line:
                sprite.sprite = sprites[0];
                break;
            case WhatIsIt.Angle:
                sprite.sprite = sprites[1];
                break;
            case WhatIsIt.Triple:
                sprite.sprite = sprites[2];
                break;
            case WhatIsIt.Comp:
                sprite.sprite = sprites[3];
                break;
            case WhatIsIt.Serv:
                sprite.sprite = sprites[4];
                break;
        }
        sprite.color = Color.white;
        transform.Rotate(new Vector3(0, 0, -90 * startPos));
        _currentPos = startPos;
        inited = true;
    }

    public void InvisibleSprite()
    {
        sprite.color = new Color(0, 0, 0, 0);
    }
    
    
    public void Rotate()
    {
        if (_whatIsIt != WhatIsIt.Comp && _whatIsIt != WhatIsIt.Serv)
        {
            transform.Rotate(new Vector3(0, 0, -90));
            _currentPos += 1;
            _currentPos = GetPos(_currentPos);
        }
    }

    public bool IsRightPos()
    {
        if (_whatIsIt == WhatIsIt.Line)
            return GetPos(_currentPos) == _rightPos || GetPos(_currentPos + 2) == _rightPos;
        else if (_whatIsIt == WhatIsIt.Angle)
            return GetPos(_currentPos) == _rightPos;
        else if (_whatIsIt == WhatIsIt.Triple)
            return GetPos(_currentPos) == _rightPos;
        return _currentPos == _rightPos;
    }

    private int GetPos(int pos)
    {
        if (pos >= 4)
            pos -= 4;
        return pos;
    }
}
