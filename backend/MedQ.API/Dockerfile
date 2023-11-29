#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MedQ.API/MedQ.API.csproj", "MedQ.API/"]
COPY ["MedQ.Infra.IoC/MedQ.Infra.IoC.csproj", "MedQ.Infra.IoC/"]
COPY ["MedQ.Application/MedQ.Application.csproj", "MedQ.Application/"]
COPY ["MedQ.Domain/MedQ.Domain.csproj", "MedQ.Domain/"]
COPY ["MedQ.Infra.Data/MedQ.Infra.Data.csproj", "MedQ.Infra.Data/"]
RUN dotnet restore "MedQ.API/MedQ.API.csproj"
COPY . .
WORKDIR "/src/MedQ.API"
RUN dotnet build "MedQ.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MedQ.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MedQ.API.dll"]