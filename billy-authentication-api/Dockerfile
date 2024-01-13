FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:3000

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["billy-authentication-api.csproj", "./"]
RUN dotnet restore "billy-authentication-api.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "billy-authentication-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "billy-authentication-api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "billy-authentication-api.dll"]
