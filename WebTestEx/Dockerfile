#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 23

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebTestEx/WebTestEx.csproj", "WebTestEx/"]
RUN dotnet restore "WebTestEx/WebTestEx.csproj"
COPY . .
WORKDIR "/src/WebTestEx"
RUN dotnet build "WebTestEx.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebTestEx.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#COPY ["WebTestEx/appsettings.json", "./"]

ENTRYPOINT ["dotnet", "WebTestEx.dll"]