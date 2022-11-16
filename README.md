<div align="center">
    <img src="https://logos-world.net/wp-content/uploads/2022/01/NET-Framework-Symbol.png" width="200" alt="Twitter bot logo"/><br>
    <b style="font-size:25px">SQL Compact Export</b><br>
    <a href="https://dotnet.microsoft.com/en-us/download/dotnet-framework/net472"><img src="https://img.shields.io/badge/NetFramework-v4.7.2-00a0dc?label=.NET Framework&style=flat&logo=dotnet" alt=".NET Framework Logo"/></a>
</div>

## About

Exports contents of SQL CE database into CSV readable formats.

## Prerequisites
This binary requires prerequisites in order to run.

- None, all dependencies are embedded in the binary. You don't need to install SQL Server Compact Runtime.

## Usage

```powershell
.\SqlCompactExport.exe --help
.\SqlCompactExport.exe --databasefile "path-to/sample.sdf" --query "SELECT * FROM [Products]" 
```

## Note

This is a mirror copy of https://github.com/KeirLoire/sql-compact-export which is also mine.