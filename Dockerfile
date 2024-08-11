FROM mcr.microsoft.com/dotnet/sdk:8.0 as build

ARG Version
WORKDIR /app

COPY ./Common.Build.props ./
COPY ./CSharpFunctionalExtensions/CSharpFunctionalExtensions.csproj ./CSharpFunctionalExtensions/
COPY ./CSharpFunctionalExtensions.StrongName/CSharpFunctionalExtensions.StrongName.csproj ./CSharpFunctionalExtensions.StrongName/
COPY ./CSharpFunctionalExtensions.Tests/CSharpFunctionalExtensions.Tests.csproj ./CSharpFunctionalExtensions.Tests/
RUN dotnet restore ./CSharpFunctionalExtensions/CSharpFunctionalExtensions.csproj
RUN dotnet restore ./CSharpFunctionalExtensions.StrongName/CSharpFunctionalExtensions.StrongName.csproj
RUN dotnet restore ./CSharpFunctionalExtensions.Tests/CSharpFunctionalExtensions.Tests.csproj

COPY ./CSharpFunctionalExtensions ./CSharpFunctionalExtensions
COPY ./CSharpFunctionalExtensions.StrongName ./CSharpFunctionalExtensions.StrongName
COPY ./CSharpFunctionalExtensions.Tests ./CSharpFunctionalExtensions.Tests
RUN dotnet build -c Release --no-restore "./CSharpFunctionalExtensions/CSharpFunctionalExtensions.csproj" /p:Version=$Version
RUN dotnet build -c Release --no-restore "./CSharpFunctionalExtensions.StrongName/CSharpFunctionalExtensions.StrongName.csproj" /p:Version=$Version
RUN dotnet build -c Release --no-restore "./CSharpFunctionalExtensions.Tests/CSharpFunctionalExtensions.Tests.csproj" /p:Version=$Version

RUN dotnet test "./CSharpFunctionalExtensions.Tests/CSharpFunctionalExtensions.Tests.csproj" -c Release --no-build --no-restore --logger "trx;LogFileName=testresults.trx"; exit 0

RUN dotnet pack "./CSharpFunctionalExtensions/CSharpFunctionalExtensions.csproj" -c Release --no-restore --no-build -o /app/out /p:Version=$Version
RUN dotnet pack "./CSharpFunctionalExtensions.StrongName/CSharpFunctionalExtensions.StrongName.csproj" -c Release --no-restore --no-build -o /app/out-sn /p:Version=$Version
