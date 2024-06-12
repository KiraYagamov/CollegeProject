using Chess;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private bool blackStep;
    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private GameObject cellHolder;
    public Cell selectedCell;
    private readonly Cell[,] _cells = new Cell[8,8];
    [SerializeField] private UIController uiController;

    private void Start()
    {
        GenerateCells();
    }
    private void GenerateCells()
    {
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                Cell cell = Instantiate(cellPrefab, cellHolder.transform).GetComponent<Cell>();
                _cells[x, y] = cell;
                cell.transform.position = new Vector3(x, y, 0);
                cell.coord = new Vector2Int(x, y);
                if (y == 1)
                {
                    cell.SetFigure(Figure.WhitePawn);
                    continue;
                }

                if (y == 6)
                {
                    cell.SetFigure(Figure.BlackPawn);
                    continue;
                }
                
                if (x == 0 || x == 7)
                {
                    if (y == 0) cell.SetFigure(Figure.WhiteRock);
                    else if (y == 7) cell.SetFigure(Figure.BlackRock);
                    continue;
                }
                if (x == 1 || x == 6)
                {
                    if (y == 0) cell.SetFigure(Figure.WhiteKnight);
                    else if (y == 7) cell.SetFigure(Figure.BlackKnight);
                    continue;
                }
                if (x == 2 || x == 5)
                {
                    if (y == 0) cell.SetFigure(Figure.WhiteBishop);
                    else if (y == 7) cell.SetFigure(Figure.BlackBishop);
                    continue;
                }
                if (x == 3)
                {
                    if (y == 0) cell.SetFigure(Figure.WhiteQueen);
                    else if (y == 7) cell.SetFigure(Figure.BlackQueen);
                    continue;
                }
                if (x == 4)
                {
                    if (y == 0) cell.SetFigure(Figure.WhiteKing);
                    else if (y == 7) cell.SetFigure(Figure.BlackKing);
                    continue;
                }

                cell.SetFigure(Figure.None);
            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit)
            {
                Cell cell = hit.transform.GetComponent<Cell>();
                if (cell.GetFigure() == Figure.Point || cell.figureRenderer.color == Color.red)
                {
                    if (cell.GetFigure() == Figure.WhiteKing || cell.GetFigure() == Figure.BlackKing)
                    {
                        uiController.GameOver();
                        QuestManager.Quest2++;
                    }
                    blackStep = selectedCell.color == FigureColor.White;
                    cell.SetFigure(selectedCell.GetFigure());
                    selectedCell.SetFigure(Figure.None);
                    ClearPoints();
                    selectedCell = null;
                    return;
                }
                if (selectedCell != null) ClearPoints();
                selectedCell = cell;
                if (cell.color == FigureColor.White && !blackStep || cell.color == FigureColor.Black && blackStep)
                {
                    if (cell.GetFigure() == Figure.BlackPawn || cell.GetFigure() == Figure.WhitePawn)
                    {
                        GetPawnPoints(cell.coord, cell.color);
                    }
                    else if (cell.GetFigure() == Figure.BlackKnight || cell.GetFigure() == Figure.WhiteKnight)
                    {
                        GetKnightPoints(cell.coord, cell.color);
                    }
                    else if (cell.GetFigure() == Figure.BlackRock || cell.GetFigure() == Figure.WhiteRock)
                    {
                        GetRockPoints(cell.coord, cell.color);
                    }
                    else if (cell.GetFigure() == Figure.BlackBishop || cell.GetFigure() == Figure.WhiteBishop)
                    {
                        GetBishopPoints(cell.coord, cell.color);
                    }
                    else if (cell.GetFigure() == Figure.BlackQueen || cell.GetFigure() == Figure.WhiteQueen)
                    {
                        GetRockPoints(cell.coord, cell.color);
                        GetBishopPoints(cell.coord, cell.color);
                    }
                    else if (cell.GetFigure() == Figure.BlackKing || cell.GetFigure() == Figure.WhiteKing)
                    {
                        GetKingPoints(cell.coord, cell.color);
                    }
                }
            }
        }
    }

    private void ClearPoints()
    {
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                if (_cells[x, y].GetFigure() == Figure.Point) _cells[x, y].SetFigure(Figure.None);
                _cells[x, y].figureRenderer.color = Color.white;
            }
        }
    }

    private void GetPawnPoints(Vector2Int startCoord, FigureColor color)
    {
        if (color == FigureColor.White)
        {
            for (int i = startCoord.y + 1; i <= startCoord.y + 2; i++)
            {
                if (i < 0 || i > 7) break;
                if (_cells[startCoord.x, i].GetFigure() == Figure.None)
                {
                    _cells[startCoord.x, i].SetFigure(Figure.Point);
                }
                else
                {
                    break;
                }
            }

            if (startCoord.x - 1 >= 0 && startCoord.y + 1 <= 7)
            {
                if (_cells[startCoord.x - 1, startCoord.y + 1].color == FigureColor.Black)
                {
                    _cells[startCoord.x - 1, startCoord.y + 1].figureRenderer.color = Color.red;
                }
            }

            if (startCoord.x + 1 <= 7 && startCoord.y + 1 <= 7)
            {
                if (_cells[startCoord.x + 1, startCoord.y + 1].color == FigureColor.Black)
                {
                    _cells[startCoord.x + 1, startCoord.y + 1].figureRenderer.color = Color.red;
                }
            }
        }
        else
        {
            for (int i = startCoord.y - 1; i >= startCoord.y - 2; i--)
            {
                if (i < 0 || i > 7) break;
                if (_cells[startCoord.x, i].GetFigure() == Figure.None)
                {
                    _cells[startCoord.x, i].SetFigure(Figure.Point);
                }
                else
                {
                    break;
                }
            }

            if (startCoord.x - 1 >= 0 && startCoord.y - 1 >= 0)
            {
                if (_cells[startCoord.x - 1, startCoord.y - 1].color == FigureColor.White)
                {
                    _cells[startCoord.x - 1, startCoord.y - 1].figureRenderer.color = Color.red;
                }
            }

            if (startCoord.x + 1 <= 7 && startCoord.y - 1 >= 0)
            {
                if (_cells[startCoord.x + 1, startCoord.y - 1].color == FigureColor.White)
                {
                    _cells[startCoord.x + 1, startCoord.y - 1].figureRenderer.color = Color.red;
                }
            }
        }
    }

    private void GetKnightPoints(Vector2Int startCoord, FigureColor color)
    {
        Vector2Int[] checkCells =
        {
            new (startCoord.x-1, startCoord.y+2), new (startCoord.x+1, startCoord.y+2),
            new (startCoord.x-1, startCoord.y-2), new (startCoord.x+1, startCoord.y-2),
            new (startCoord.x+2, startCoord.y-1), new (startCoord.x+2, startCoord.y+1),
            new (startCoord.x-2, startCoord.y-1), new (startCoord.x-2, startCoord.y+1),
        };
        foreach (var cell in checkCells)
        {
            if (cell.x >= 0 && cell.x <= 7 && cell.y >= 0 && cell.y <= 7)
            {
                if (_cells[cell.x, cell.y].GetFigure() == Figure.None)
                {
                    _cells[cell.x, cell.y].SetFigure(Figure.Point);
                }
                else if (_cells[cell.x, cell.y].color != color && _cells[cell.x, cell.y].color != FigureColor.Nothing)
                {
                    _cells[cell.x, cell.y].figureRenderer.color = Color.red;
                }
            }
        }
    }

    private void GetRockPoints(Vector2Int startCoord, FigureColor color)
    {
        for (int y = startCoord.y + 1; y < 8; y++)
        {
            if (_cells[startCoord.x, y].GetFigure() == Figure.None)
            {
                _cells[startCoord.x, y].SetFigure(Figure.Point);
            }
            else if (_cells[startCoord.x, y].color != color && _cells[startCoord.x, y].color != FigureColor.Nothing)
            {
                _cells[startCoord.x, y].figureRenderer.color = Color.red;
                break;
            }
            else
            {
                break;
            }
        }
        for (int y = startCoord.y - 1; y >= 0; y--)
        {
            if (_cells[startCoord.x, y].GetFigure() == Figure.None)
            {
                _cells[startCoord.x, y].SetFigure(Figure.Point);
            }
            else if (_cells[startCoord.x, y].color != color && _cells[startCoord.x, y].color != FigureColor.Nothing)
            {
                _cells[startCoord.x, y].figureRenderer.color = Color.red;
                break;
            }
            else
            {
                break;
            }
        }
        for (int x = startCoord.x + 1; x < 8; x++)
        {
            if (_cells[x, startCoord.y].GetFigure() == Figure.None)
            {
                _cells[x, startCoord.y].SetFigure(Figure.Point);
            }
            else if (_cells[x, startCoord.y].color != color && _cells[x, startCoord.y].color != FigureColor.Nothing)
            {
                _cells[x, startCoord.y].figureRenderer.color = Color.red;
                break;
            }
            else
            {
                break;
            }
        }
        for (int x = startCoord.x - 1; x >= 0; x--)
        {
            if (_cells[x, startCoord.y].GetFigure() == Figure.None)
            {
                _cells[x, startCoord.y].SetFigure(Figure.Point);
            }
            else if (_cells[x, startCoord.y].color != color && _cells[x, startCoord.y].color != FigureColor.Nothing)
            {
                _cells[x, startCoord.y].figureRenderer.color = Color.red;
                break;
            }
            else
            {
                break;
            }
        }
    }

    private void GetBishopPoints(Vector2Int startCoord, FigureColor color)
    {
        for (int i = 1; i < 8; i++)
        {
            int x = startCoord.x + i;
            int y = startCoord.y + i;
            
            if (x > 7 || y > 7 || x < 0 || y < 0) break;

            Cell cell = _cells[x, y];
            if (cell.GetFigure() == Figure.None)
            {
                cell.SetFigure(Figure.Point);
            }
            else if (cell.color != color && cell.color != FigureColor.Nothing)
            {
                cell.figureRenderer.color = Color.red;
                break;
            }
            else
            {
                break;
            }
        }
        for (int i = 1; i < 8; i++)
        {
            int x = startCoord.x - i;
            int y = startCoord.y + i;
            
            if (x > 7 || y > 7 || x < 0 || y < 0) break;

            Cell cell = _cells[x, y];
            if (cell.GetFigure() == Figure.None)
            {
                cell.SetFigure(Figure.Point);
            }
            else if (cell.color != color && cell.color != FigureColor.Nothing)
            {
                cell.figureRenderer.color = Color.red;
                break;
            }
            else
            {
                break;
            }
        }
        for (int i = 1; i < 8; i++)
        {
            int x = startCoord.x + i;
            int y = startCoord.y - i;
            
            if (x > 7 || y > 7 || x < 0 || y < 0) break;

            Cell cell = _cells[x, y];
            if (cell.GetFigure() == Figure.None)
            {
                cell.SetFigure(Figure.Point);
            }
            else if (cell.color != color && cell.color != FigureColor.Nothing)
            {
                cell.figureRenderer.color = Color.red;
                break;
            }
            else
            {
                break;
            }
        }
        for (int i = 1; i < 8; i++)
        {
            int x = startCoord.x - i;
            int y = startCoord.y - i;
            
            if (x > 7 || y > 7 || x < 0 || y < 0) break;

            Cell cell = _cells[x, y];
            if (cell.GetFigure() == Figure.None)
            {
                cell.SetFigure(Figure.Point);
            }
            else if (cell.color != color && cell.color != FigureColor.Nothing)
            {
                cell.figureRenderer.color = Color.red;
                break;
            }
            else
            {
                break;
            }
        }
    }

    private void GetKingPoints(Vector2Int startCoord, FigureColor color)
    {
        Vector2Int[] checkCells =
        {
            new (startCoord.x, startCoord.y+1), new (startCoord.x+1, startCoord.y+1), new (startCoord.x-1, startCoord.y+1),
            new (startCoord.x, startCoord.y-1), new (startCoord.x+1, startCoord.y-1), new (startCoord.x-1, startCoord.y-1),
            new (startCoord.x+1, startCoord.y), new (startCoord.x-1, startCoord.y),
        };
        foreach (var cell in checkCells)
        {
            if (cell.x >= 0 && cell.x <= 7 && cell.y >= 0 && cell.y <= 7)
            {
                if (_cells[cell.x, cell.y].GetFigure() == Figure.None)
                {
                    _cells[cell.x, cell.y].SetFigure(Figure.Point);
                }
                else if (_cells[cell.x, cell.y].color != color && _cells[cell.x, cell.y].color != FigureColor.Nothing)
                {
                    _cells[cell.x, cell.y].figureRenderer.color = Color.red;
                }
            }
        }
    }
}
