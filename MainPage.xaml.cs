using FigureMotionApp.Models;

namespace FigureMotionApp;

public partial class MainPage : ContentPage
{
    private readonly Random _random = new();
    private IDispatcherTimer _timer;

    public MainPage()
    {
        InitializeComponent();
        
        [cite_start]
        _timer = Dispatcher.CreateTimer();
        _timer.Interval = TimeSpan.FromMilliseconds(16);
        _timer.Tick += (s, e) => CanvasView.Invalidate(); 
        _timer.Start();
    }

    private void OnAddShapeClicked(object sender, EventArgs e)
    {
        [cite_start]
        Task.Run(() => CreateNewShapeTask());
    }

    private void CreateNewShapeTask()
    {
        var shape = new ShapeItem
        {
            Type = _random.Next(2) == 0 ? ShapeType.Circle : ShapeType.Square,
            ShapeColor = Color.FromRgb(_random.Next(256), _random.Next(256), _random.Next(256)),
            X = 50,
            Y = 50,
            [cite_start]
            SpeedX = _random.Next(2) == 0 ? _random.Next(2, 7) : 0,
            SpeedY = 0 
        };
        
        if (shape.SpeedX == 0) shape.SpeedY = _random.Next(2, 7);

        [cite_start]
        MainThread.BeginInvokeOnMainThread(() => {
            MainDrawable.Shapes.Add(shape);
        });


        while (true)
        {
            shape.Move(CanvasView.Width, CanvasView.Height);
            Thread.Sleep(20); 
        }
    }
}