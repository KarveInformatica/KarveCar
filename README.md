# KarveCar
A new generation of car rental software
![alt text](https://github.com/KarveInformatica/KarveCar/blob/master/src/sample.png)

# Build instructions.
Requirements:
- Microsoft Visual Studio 2017 code
- Python
- Set up the msbuild path following the instructions:
1. Run PowerShell as Admininistrator.
The following command is to get the current path from PowerShell.
2. Get-ItemProperty -Path 'Registry::HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\Session Manager\Environment' -Name PATH
3. Read the path to local variable
$theCurrentPath=(Get-ItemProperty -Path 'Registry::HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\Session Manager\Environment' -Name PATH).Path
4. Update the path with the command: $theUpdatedPath=$theCurrentPath+’;C:\Program Files (x86)\Microsoft Visual Studio\2017\BuildTools\MSBuild\15.0\Bin’
5. Set the path to the updated path.
Set-ItemProperty -Path 'Registry::HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\Session Manager\Environment' -Name PATH –Value $theUpdatedPath
7. Check if nuget is installed. Otherwise Install NuGet:
  - Tools > Get Tools and Features...
  - Single Component > Code Tools
  - √ NuGet package manager
  - Update. To find NuGet: - Project >  Manage NuGet packages... - Tools > NuGet Package Manager
6. Go to src:
   dotnet restore KarveCar.sln
   msbuild KarveCar.sln /m
