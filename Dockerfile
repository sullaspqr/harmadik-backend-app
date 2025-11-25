# Build fázis
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Másoljuk a projekt fájljait
COPY . ./

# Restore a függőségekhez
RUN dotnet restore

# Publish (Release konfigurációval)
RUN dotnet publish -c Release -o /app/out

# Futtató image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Másoljuk át a buildelt fájlokat
COPY --from=build /app/out ./

# Alapértelmezett port (opcionális, ha használod)
EXPOSE 80
# Ha HTTPS is kell:
# EXPOSE 443

# Indítás
ENTRYPOINT ["dotnet", "harmadik-backend-app.dll"]
