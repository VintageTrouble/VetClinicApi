#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["VetClinicApi.API/VetClinicApi.API.csproj", "VetClinicApi.API/"]
COPY ["VetClinicApi.Application/VetClinicApi.Application.csproj", "VetClinicApi.Application/"]
COPY ["VetClinicApi.Database.Migrations/VetClinicApi.Database.Migrations.csproj", "VetClinicApi.Database.Migrations/"]
COPY ["VetClinicApi.Database/VetClinicApi.Database.csproj", "VetClinicApi.Database/"]
COPY ["VetClinicApi.Core/VetClinicApi.Core.csproj", "VetClinicApi.Core/"]
RUN dotnet restore "VetClinicApi.API/VetClinicApi.API.csproj"
COPY . .
WORKDIR "/src/VetClinicApi.API"
RUN dotnet build "VetClinicApi.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VetClinicApi.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VetClinicApi.API.dll"]