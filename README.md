# VideoStreamer
Overview
VideoStreamer is a powerful and user-friendly WPF desktop application designed for seamless video streaming using the RTSP (Real-Time Streaming Protocol). This application leverages the capabilities of VLC for high-quality, low-latency streaming, making it ideal for various applications, including surveillance, live broadcasting, and multimedia streaming.

Features
High-Quality Streaming: Stream video content with minimal latency and high fidelity using the robust VLC engine.
User-Friendly Interface: A clean and intuitive UI that simplifies the streaming process.
Flexible Media Options: Supports various media options for customizing your streaming experience.
Open Source: Fully open-source, allowing for customization and enhancement.
Getting Started
Prerequisites
Windows 10/11
.NET Core SDK (version 3.1 or later)
Visual Studio (2019 or later with .NET desktop development workload)
VLC Media Player installed (make sure to note the installation directory)
Installation
Clone the Repository

sh
Copy code
git clone https://github.com/AbdelrahmanMoh-Hussain/VideoStreamer.git
cd VideoStreamer
Open the Project in Visual Studio

Open VideoStreamer.sln in Visual Studio.
Restore NuGet Packages

Right-click on the solution in the Solution Explorer and select Restore NuGet Packages.
Configure VLC Path

Ensure the VLC library path is correctly set in MainWindow.xaml.cs.
Build and Run

Press F5 to build and run the application.
Usage
Launch the Application

Start VideoStreamer from Visual Studio or the executable file in the build directory.
Start Streaming

Enter the RTSP stream URL in the designated field.
Click on the Start Stream button to begin streaming.
Enjoy the live stream displayed in the application window.
