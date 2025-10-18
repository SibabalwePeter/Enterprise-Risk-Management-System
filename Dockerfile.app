# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution and project files
COPY Enterprise.sln .
COPY ERMS.app/ERMS.app.csproj ERMS.app/
COPY ERMS.BL/ERMS.BL.csproj ERMS.BL/
COPY ERMS.DAL/ERMS.DAL.csproj ERMS.DAL/
COPY ERMS.DL/ERMS.DL.csproj ERMS.DL/

# Restore dependencies
RUN dotnet restore "Enterprise.sln"

# Copy everything else and build
COPY . .
RUN dotnet build "Enterprise.sln" -c Release --no-restore

# Publish App project
WORKDIR "/src/ERMS.app"
RUN dotnet publish "ERMS.app.csproj" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ERMS.app.dll"]