#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Catalog/Catalog.API/Catalog.API.csproj", "Services/Catalog/Catalog.API/"]
COPY ["Services/Catalog/Application/Application.csproj", "Services/Catalog/Application/"]
COPY ["Services/Catalog/Domain/Domain.csproj", "Services/Catalog/Domain/"]
COPY ["Services/ServicesShared.Core/ServicesShared.Core/ServicesShared.Core.csproj", "Services/ServicesShared.Core/ServicesShared.Core/"]
COPY ["Services/Catalog/Persistence/Persistence.csproj", "Services/Catalog/Persistence/"]
COPY ["Services/Catalog/Services/Services.csproj", "Services/Catalog/Services/"]
RUN dotnet restore "Services/Catalog/Catalog.API/Catalog.API.csproj"
COPY . .
WORKDIR "/src/Services/Catalog/Catalog.API"
RUN dotnet build "Catalog.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Catalog.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Catalog.API.dll"]
