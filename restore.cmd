@echo off

rem Partially based on ideas from https://github.com/loresoft/KickStart

md packages
.nuget\nuget restore CSharpFunctionalExtensions.sln -PackagesDirectory packages
.nuget\nuget install Tools\packages.config -OutputDirectory Tools -ExcludeVersion -NonInteractive

