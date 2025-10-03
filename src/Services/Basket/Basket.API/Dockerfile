FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy csproj files explicitly (relative to context = repo root)
COPY Services/Basket/Basket.API/Basket.API.csproj Services/Basket/Basket.API/
COPY Common/Common/Common.csproj Common/Common/

# Restore as distinct layer
RUN dotnet restore Services/Basket/Basket.API/Basket.API.csproj

# Copy the entire repo
COPY . .

# Set working directory for build
WORKDIR /src/Services/Basket/Basket.API
RUN dotnet build Basket.API.csproj -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish Basket.API.csproj -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Basket.API.dll"]
