FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./game-nation-shared/game-nation-shared.csproj ./game-nation-shared/game-nation-shared.csproj
WORKDIR /app/game-nation-shared
RUN dotnet restore

WORKDIR /app
COPY ./game-nation-client-service/game-nation-client-service.csproj ./game-nation-client-service/game-nation-client-service.csproj
WORKDIR /app/game-nation-client-service
RUN dotnet restore

# Copy everything else and build
WORKDIR /app
COPY ./game-nation-shared/* ./game-nation-shared/
WORKDIR /app/game-nation-shared
RUN dotnet publish -c Release -o out

WORKDIR /app
COPY ./game-nation-client-service/* ./game-nation-client-service/
WORKDIR /app/game-nation-client-service
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /app
COPY --from=build-env /app/game-nation-client-service/out .
ENTRYPOINT ["dotnet", "game-nation-client-service.dll"]