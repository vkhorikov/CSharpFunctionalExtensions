FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build

ENV MONO_VERSION 5.4.1.6

RUN apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF

RUN echo "deb http://download.mono-project.com/repo/debian stretch/snapshots/$MONO_VERSION main" > /etc/apt/sources.list.d/mono-official.list \
  && apt-get update \
  && apt-get install -y mono-runtime \
  && rm -rf /var/lib/apt/lists/* /tmp/*

RUN apt-get update \
  && apt-get install -y binutils curl mono-devel ca-certificates-mono fsharp mono-vbnc nuget referenceassemblies-pcl \
  && rm -rf /var/lib/apt/lists/* /tmp/*

ARG Version
WORKDIR /app

COPY ./CSharpFunctionalExtensions.sln ./netfx.props ./
COPY ./CSharpFunctionalExtensions/CSharpFunctionalExtensions.csproj ./CSharpFunctionalExtensions/
COPY ./CSharpFunctionalExtensions.Tests/CSharpFunctionalExtensions.Tests.csproj ./CSharpFunctionalExtensions.Tests/
RUN dotnet restore ./CSharpFunctionalExtensions/CSharpFunctionalExtensions.csproj
RUN dotnet restore ./CSharpFunctionalExtensions.Tests/CSharpFunctionalExtensions.Tests.csproj

COPY ./CSharpFunctionalExtensions ./CSharpFunctionalExtensions
COPY ./CSharpFunctionalExtensions.Tests ./CSharpFunctionalExtensions.Tests
RUN dotnet build -c Release --no-restore "./CSharpFunctionalExtensions/CSharpFunctionalExtensions.csproj" /p:Version=$Version
RUN dotnet build -c Release --no-restore "./CSharpFunctionalExtensions.Tests/CSharpFunctionalExtensions.Tests.csproj" /p:Version=$Version

RUN dotnet test "./CSharpFunctionalExtensions.Tests/CSharpFunctionalExtensions.Tests.csproj" -c Release --no-build --no-restore

RUN dotnet pack "./CSharpFunctionalExtensions/CSharpFunctionalExtensions.csproj" -c Release --no-restore --no-build -o /app/out /p:Version=$Version
