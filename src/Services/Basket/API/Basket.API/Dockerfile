#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Basket/API/Basket.API/Basket.API.csproj", "Services/Basket/API/Basket.API/"]
COPY ["Services/Basket/Data/Data/Data.csproj", "Services/Basket/Data/Data/"]
COPY ["Services/Basket/Core/Core/Core.csproj", "Services/Basket/Core/Core/"]
COPY ["Services/Basket/Services/Services/Services.csproj", "Services/Basket/Services/Services/"]
RUN dotnet restore "Services/Basket/API/Basket.API/Basket.API.csproj"
COPY . .
WORKDIR "/src/Services/Basket/API/Basket.API"
RUN dotnet build "Basket.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Basket.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Basket.API.dll"]
