namespace FigureMotionApp.Models;

public enum ShapeType { Circle, Square }

public class ShapeItem
{
    public ShapeType Type { get; set; }
    public Color ShapeColor { get; set; }
    public float X { get; set; }
    public float Y { get; set; }
    public float SpeedX { get; set; }
    public float SpeedY { get; set; }
    public const int Size = 40;

    public void Move(double boundaryWidth, double boundaryHeight)
    {
        X += SpeedX;
        Y += SpeedY;

        [cite_start]
        if (X <= 0 || X + Size >= boundaryWidth) SpeedX *= -1;
        if (Y <= 0 || Y + Size >= boundaryHeight) SpeedY *= -1;
    }
}