\# Konica Minolta CM600-700D Driver

C# Driver for the Konica Minolta CM600-700D spectrophotometer. The Driver can be utilised by calling an instance of the Konica Driver interface, the functions to which are detailed in the Doxygen document accompanying this.

\## Installation

Build the source code in VS Code or Visual Studio and the DLL will be in the bin file of the directory

\#### "C:\KonicaDriver\bin\Debug\net6.0\KonicaDriver.dll"


\## References and Dependencies

* [LibUsbDotNet](http://sourceforge.net/projects/libusbdotnet) is a .NET C# USB library for WinUsb, libusb-win32, and Linux libusb v1.x developers.

All basic USB device functionality can be performed through common device classes allowing you to write OS and driver independent code.

\## Known Issue

When the device is performing a measure the driver polls the device intermittently to record the experiment duration and say when the experiments done. If the device stops unexpectedly due to low battery, the FunctionStatus won’t report the BatteryTooLow error due to the nature in which you poll the device for an update on the measurement.
