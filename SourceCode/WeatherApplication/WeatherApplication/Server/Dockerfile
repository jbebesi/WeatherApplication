#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["WeatherApplication/Server/WeatherApplication.Server.csproj", "WeatherApplication/Server/"]
COPY ["WeatherApplication/Shared/WeatherApplication.Shared.csproj", "WeatherApplication/Shared/"]
COPY ["WeatherApplication/Client/WeatherApplication.Client.csproj", "WeatherApplication/Client/"]
RUN dotnet restore "WeatherApplication/Server/WeatherApplication.Server.csproj"
COPY . .
WORKDIR "/src/WeatherApplication/Server"
RUN dotnet build "WeatherApplication.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WeatherApplication.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeatherApplication.Server.dll"]