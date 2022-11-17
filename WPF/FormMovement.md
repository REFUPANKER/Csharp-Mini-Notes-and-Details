# CSharp-WPF-Form-Movement-Code
Form Movement Code { for not resizable / no-border forms and any items too }
##### Properties 
+ Moves Form in screen with mouse
+ Stucks Form in screen (cant move out of border)
### Here is the code :
```csharp
// Paste this to empty area top of mouse events (1 time o_o)
Point movementPoint;
// Paste this to item's "MouseMove" Event (that item will used for moving form)
if (Mouse.LeftButton == MouseButtonState.Pressed)
{
  if (e.GetPosition(null).X <= movementPoint.X && this.Left>=0 || e.GetPosition(null).X >= movementPoint.X && this.Left+this.Width<=SystemParameters.PrimaryScreenWidth) 
  {
    this.Left += e.GetPosition(null).X - movementPoint.X;
  }
  if (e.GetPosition(null).Y<=movementPoint.Y && this.Top>=0 || e.GetPosition(null).Y>=movementPoint.Y && this.Top+this.Height<=SystemParameters.VirtualScreenHeight)
  {
    this.Top += e.GetPosition(null).Y - movementPoint.Y;
  }
}
// Paste this to item's "MouseDown" Event (that item will used for detect starting point)
movementPoint = e.GetPosition(null);
```
### More explanation with code
```csharp
        public MainWindow()
        {
            InitializeComponent();
// Generate Events
            BasePanel.MouseDown += BasePanel_MouseDown1;
            BasePanel.MouseMove += BasePanel_MouseMove1;   
        }
        
// here is the item's movement point
        Point movementPoint;

// here is the item's mouseDown
        private void BasePanel_MouseDown1(object sender, MouseButtonEventArgs e)
        {
            movementPoint = e.GetPosition(null);
        }

// here is the item's mouseMove
        private void BasePanel_MouseMove1(object sender, MouseEventArgs e)
        {
if (Mouse.LeftButton == MouseButtonState.Pressed)
{
if (e.GetPosition(null).X <= movementPoint.X && this.Left>=0 || e.GetPosition(null).X >= movementPoint.X && this.Left+this.Width<=SystemParameters.PrimaryScreenWidth) 
  {
    this.Left += e.GetPosition(null).X - movementPoint.X;
    // if you don't want to stuck form into screen remove "if" block
  }
  if (e.GetPosition(null).Y<=movementPoint.Y && this.Top>=0 || e.GetPosition(null).Y>=movementPoint.Y && this.Top+this.Height<=SystemParameters.VirtualScreenHeight)
  {
    this.Top += e.GetPosition(null).Y - movementPoint.Y;
    // if you don't want to stuck form into screen remove "if" block
  }
}
        }

    }
```
