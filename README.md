# KarveCar
A new generation of car rental software
![alt text](https://github.com/KarveInformatica/KarveCar/blob/master/src/sample.png)

# Build instructions.
Requirements:
- Microsoft Visual Studio 2017 code
- Python
- Syncfusion Community License. Version 15.0.4
- Set up the msbuild path following the instructions:
1. Run PowerShell as Admininistrator.
The following command is to get the current path from PowerShell.
2. Get-ItemProperty -Path 'Registry::HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\Session Manager\Environment' -Name PATH
3. Read the path to local variable
$theCurrentPath=(Get-ItemProperty -Path 'Registry::HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\Session Manager\Environment' -Name PATH).Path
4. Update the path with the command: $theUpdatedPath=$theCurrentPath+’;C:\Program Files (x86)\Microsoft Visual Studio\2017\BuildTools\MSBuild\15.0\Bin’
5. Set the path to the updated path.
Set-ItemProperty -Path 'Registry::HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\Session Manager\Environment' -Name PATH –Value $theUpdatedPath
6. To compile you it enough:
   dotnet restore KarveCar.sln
   msbuild KarveCar.sln /m
