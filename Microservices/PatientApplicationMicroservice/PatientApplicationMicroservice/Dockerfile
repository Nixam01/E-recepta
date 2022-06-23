#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PatientApplicationMicroservice.csproj", "PatientApplicationMicroservice/"]
RUN dotnet restore "PatientApplicationMicroservice/PatientApplicationMicroservice.csproj"

WORKDIR "/src/PatientApplicationMicroservice"
COPY . .

RUN dotnet build "PatientApplicationMicroservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PatientApplicationMicroservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PatientApplicationMicroservice.dll"]