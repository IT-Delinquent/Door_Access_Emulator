# Door_Access_Emulator
### A small program that shows a basic door access system

This is a small WPF/C# program that emulates a door access system. There are buttons for 0-9 as well as "Cancel", "Enter" and "Reset Code" 
which allow all the usual operations a door access system is capable of 🔑

I built this using [Caliburn.Micro](https://github.com/Caliburn-Micro/Caliburn.Micro) for my MVVM framework 🙌 👨‍💻

The program allows for the entering of a pin and will tell you whether the pin is correct or not after clicking the enter button. If you're
pin is accepted, you can either wait for the "lock" to become activated again or press the reset code button. This allows a new four
digit pin to be entered. 

Here is a short GIF of the program in use:

![](https://github.com/IT-Delinquent/Door_Access_Emulator/blob/master/Door_Access_Emulator_GIF.gif)

By the way, the default code is 1234
