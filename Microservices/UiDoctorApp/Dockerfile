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
COPY ["UiDoctorApp/UiDoctorApp.csproj", "UiDoctorApp/"]
RUN dotnet restore "UiDoctorApp/UiDoctorApp.csproj"
COPY . .
WORKDIR "/src/UiDoctorApp"
RUN dotnet build "UiDoctorApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UiDoctorApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UiDoctorApp.dll"]