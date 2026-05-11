using FigureMotionApp.Models;

namespace FigureMotionApp.Graphics;

public class ShapeDrawable : IDrawable
{
    public List<ShapeItem> Shapes { get; set; } = new();

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        foreach (var shape in Shapes)
        {
            canvas.FillColor = shape.ShapeColor;
            if (shape.Type == ShapeType.Circle)
                canvas.FillEllipse(shape.X, shape.Y, ShapeItem.Size, ShapeItem.Size);
            else
                canvas.FillRectangle(shape.X, shape.Y, ShapeItem.Size, ShapeItem.Size);
        }
    }
}