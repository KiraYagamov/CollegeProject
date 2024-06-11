using DefaultNamespace;
using UnityEngine;

public class SysAdminController : MonoBehaviour
{
    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private GameObject bgPrefab;
    private SysAdminCell[,] _cells;
    [SerializeField] private GameObject winPanel;
    private int _currentLevel;
    
    private void Start()
    {
        GenerateBackground();
        _currentLevel = 1;
        FirstLevel();
    }

    private void GenerateBackground()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                Instantiate(bgPrefab, new Vector2(i, j), Quaternion.identity);
            }
        }
    }

    private void GenerateField()
    {
        if (_cells != null)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Destroy(_cells[i,j].gameObject);
                }
            }
        }

        _cells = new SysAdminCell[9, 9];
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                SysAdminCell cell = Instantiate(cellPrefab, new Vector2(i, j), Quaternion.identity).GetComponent<SysAdminCell>();
                cell.InvisibleSprite();
                _cells[i,j] = cell;
            }
        }
    }

    private void FirstLevel()
    {
        GenerateField();
        
        _cells[2, 5].Init(0, 0, WhatIsIt.Serv);
        _cells[4, 2].Init(0, 0, WhatIsIt.Comp);
        _cells[5, 2].Init(0, 0, WhatIsIt.Comp);
        _cells[6, 1].Init(0, 0, WhatIsIt.Comp);
        
        _cells[2, 4].Init(0, 1, WhatIsIt.Angle);
        _cells[3, 4].Init(0, 1, WhatIsIt.Line);
        _cells[4, 4].Init(2, 0, WhatIsIt.Triple);
        _cells[5, 4].Init(2, 1, WhatIsIt.Triple);
        _cells[6, 4].Init(2, 3, WhatIsIt.Angle);
        _cells[4, 3].Init(1, 0, WhatIsIt.Line);
        _cells[5, 3].Init(1, 0, WhatIsIt.Line);
        _cells[6, 3].Init(1, 0, WhatIsIt.Line);
        _cells[6, 2].Init(1, 1, WhatIsIt.Line);
    }

    private void SecondLevel()
    {
        GenerateField();
        
        _cells[2, 2].Init(0, 0, WhatIsIt.Comp);
        _cells[4, 5].Init(0, 0, WhatIsIt.Comp);
        _cells[6, 3].Init(0, 0, WhatIsIt.Serv);
        _cells[6, 7].Init(0, 0, WhatIsIt.Comp);
        
        _cells[3, 2].Init(3, 0, WhatIsIt.Angle);
        _cells[3, 3].Init(1, 2, WhatIsIt.Triple);
        _cells[4, 3].Init(0, 1, WhatIsIt.Triple);
        _cells[5, 3].Init(3, 1, WhatIsIt.Angle);
        _cells[4, 4].Init(1, 0, WhatIsIt.Line);
        _cells[5, 4].Init(1, 2, WhatIsIt.Angle);
        _cells[6, 4].Init(2, 3, WhatIsIt.Angle);
        
        _cells[3, 4].Init(1, 2, WhatIsIt.Line);
        _cells[3, 5].Init(1, 0, WhatIsIt.Line);
        _cells[3, 6].Init(1, 0, WhatIsIt.Angle);
        _cells[4, 6].Init(0, 1, WhatIsIt.Line);
        _cells[5, 6].Init(3, 1, WhatIsIt.Angle);
        _cells[5, 7].Init(1, 2, WhatIsIt.Angle);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit)
            {
                SysAdminCell cell = hit.transform.GetComponent<SysAdminCell>();
                cell.Rotate();
            }
        }
        if (CheckWin() && !winPanel.activeSelf)
            winPanel.SetActive(true);
    }

    private bool CheckWin()
    {
        bool win = true;
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (_cells[i, j].inited)
                {
                    if (!_cells[i, j].IsRightPos())
                    {
                        win = false;
                        break;
                    }
                }
            }
            if (!win)
                break;
        }

        return win;
    }

    public void NextLevel()
    {
        _currentLevel++;
        switch (_currentLevel)
        {
            case 1:
                FirstLevel();
                break;
            case 2:
                SecondLevel();
                break;
            default:
                _currentLevel = 1;
                FirstLevel();
                break;
        }
        winPanel.SetActive(false);
    }
}
