#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AppController/AppController.csproj", "AppController/"]
COPY ["AppModels/AppModels.csproj", "AppModels/"]
COPY ["Tests/Tests.csproj", "Tests/"]
COPY ["Utilities/Utilities.csproj", "Utilities/"]
COPY ["UiPatientApp/UiPatientApp.csproj", "UiPatientApp/"]
RUN dotnet restore "UiPatientApp/UiPatientApp.csproj"
COPY . .
WORKDIR "/src/UiPatientApp"
RUN dotnet build "UiPatientApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UiPatientApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UiPatientApp.dll"]