# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution and project files
COPY Enterprise\ Risk\ Management\ System.sln .
COPY ERMS.api/ERMS.api.csproj ERMS.api/
COPY ERMS.services/ERMS.BL.csproj ERMS.services/
COPY ERMS.DAL/ERMS.DAL.csproj ERMS.DAL/
COPY ERMS.core/ERMS.DL.csproj ERMS.core/

# Restore dependencies
RUN dotnet restore "Enterprise.sln"

# Copy everything else and build
COPY . .
RUN dotnet build "Enterprise.sln" -c Release --no-restore

# Publish API project
WORKDIR "/src/ERMS.api"
RUN dotnet publish "ERMS.api.csproj" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "ERMS.api.dll"]




