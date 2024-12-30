# Build Stage - SDK Image
# FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
FROM mcr.microsoft.com/dotnet/sdk:8.0-jammy AS build
# FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /source
COPY . .
RUN dotnet restore "./WhiteBrookAPI.csproj" --disable-parallel
RUN dotnet publish "./WhiteBrookAPI.csproj" -c release -o /app --no-restore

# Serve Stage - aspnet runtime image
# FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal
FROM mcr.microsoft.com/dotnet/aspnet:8.0-jammy AS base
# FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

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

ENTRYPOINT ["dotnet", "WhiteBrookAPI.dll"]

