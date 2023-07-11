#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["VetClinicApi.API/VetClinicApi.API.csproj", "VetClinicApi.API/"]
COPY ["ClassLibrary1/ClassLibrary1.csproj", "ClassLibrary1/"]
RUN dotnet restore "VetClinicApi.API/VetClinicApi.API.csproj"
COPY . .
WORKDIR "/src/VetClinicApi.API"
RUN dotnet build "VetClinicApi.API.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "VetClinicApi.API.csproj" -c Debug -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VetClinicApi.API.dll"]