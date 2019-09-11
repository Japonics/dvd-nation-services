FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./game-nation-api-gateway/game-nation-api-gateway.csproj ./game-nation-api-gateway.csproj
RUN dotnet restore

# Copy everything else and build
COPY ./game-nation-api-gateway/* ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "game-nation-api-gateway.dll"]