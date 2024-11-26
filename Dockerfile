# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./SuperHeroAPI.csproj" --disable-parallel
RUN dotnet publish "./SuperHeroAPI.csproj" -c release -o /app --no-restore

# Serve Stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal
WORKDIR /app
COPY --from=build /app ./

# Copy the certificate file
COPY aspnetapp.pfx /https/aspnetapp.pfx

# Expose ports
EXPOSE 5000
EXPOSE 5001

# Set environment variables for HTTPS
ENV ASPNETCORE_URLS="http://+:5000;https://+:5001"
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx

ENTRYPOINT ["dotnet", "SuperHeroAPI.dll"]