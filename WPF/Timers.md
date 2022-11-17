# CSharpWPF-Timers
System Timers in CSharp WPF App
### Class Requirement 
```CSharp
using System.Timers;
```
### Example
```CSharp
void TimerTest1()
{
  Timer timer1=new Timer();
  timer1.Interval=1000;
  timer1.Enabled=true;
  timer1.Elapsed+=timer1_elapsed;
  timer1.Start();
}

private void timer1_elapsed(object? sender, ElapsedEventArgs e)
{
  Dispatcher.Invoke(new Action(()=>{
    MyLabel.Content=DateTime.Now;
  }));
}
```
### About Classes
* [Action](https://docs.microsoft.com/en-us/dotnet/api/system.action?view=net-6.0)
* [Dispatcher](https://docs.microsoft.com/tr-tr/dotnet/api/system.windows.threading.dispatcher?view=windowsdesktop-6.0)
* [System Timer](https://docs.microsoft.com/tr-tr/dotnet/api/system.timers.timer?view=net-6.0)
