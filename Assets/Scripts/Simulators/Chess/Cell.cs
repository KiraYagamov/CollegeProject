using Chess;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Vector2Int coord;
    private Figure _figure = Figure.None;
    public FigureColor color = FigureColor.Nothing;
    [SerializeField] private Sprite[] figuresSprites;
    public SpriteRenderer figureRenderer;

    public void SetFigure(Figure figure)
    {
        _figure = figure;
        figureRenderer.sprite = figuresSprites[(int) figure];
        if ((int) figure > 0 && (int) figure < 7)
            color = FigureColor.White;
        else if ((int) figure > 6 && (int) figure < 13)
            color = FigureColor.Black;
        else
            color = FigureColor.Nothing;
    }

    public Figure GetFigure()
    {
        return _figure;
    }
}
