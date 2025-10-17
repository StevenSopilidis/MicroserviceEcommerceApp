FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy csproj files explicitly (relative to context = repo root)
COPY Services/Discount/Discount.API/Discount.API.csproj Services/Discount/Discount.API/
COPY Common/Common/Common.csproj Common/Common/

# Restore as distinct layer
RUN dotnet restore Services/Discount/Discount.API/Discount.API.csproj

# Copy the entire repo
COPY . .

# Set working directory for build
WORKDIR /src/Services/Discount/Discount.API
RUN dotnet build Discount.API.csproj -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish Discount.API.csproj -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Discount.API.dll"]
