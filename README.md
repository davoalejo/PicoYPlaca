# PicoYPlaca
A "Pico Y Placa" predictor

How to run the project:

- You only need to run the executable file generated in the bin folder (.../PicoYPlaca/PicoYPlaca/bin/Debug/)

How to run the Unit Tests

- From cmd preferible powershell, you go the folder (.../PicoYPlaca/PicoYPlaca.Tests/bin/Debug/)
- Enter the command 
 - dotnet vstest PicoYPlaca.Tests.dll /Framework:.NETFramework,Version=v4.7.2 /TestAdapterPath:C:\PicoYPlaca-master\packages\MSTest.TestAdapter.1.3.2
 - You might need to change the value after /TestAdapterPath: for the path where the solution files are stored.
 - And press ENTER.

Inputs:
 - A valid ecuadorian License Plate (Validations include Special plates(Diplomatic, etc), 
 Public plates(Vehicles used for public transportation, etc)  & Motorcycle plates)
 - A valid Date in the format "dd/MM/yyyy"
 - A valid Timespan in the format "HH:mm"
 
 Output:
 - The output will be a message that indicates wheater or not you can circulate.
 
 Folders:
  - PicoYPlaca:       Contains the project with the code of the console application.
  - PicoYPlaca.Util   Contains the project with the logic and models used for the Pico Y Placa predictor.
  - PicoYPlaca.Tests  Contains the project with the Unit Tests applied for the Classses in PicoYPlaca.Util project
