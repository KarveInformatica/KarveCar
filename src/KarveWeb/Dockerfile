FROM microsoft/aspnetcore:2.0-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-nanoserver-1709 AS build
WORKDIR /src
COPY ../KarveWeb/KarveWeb.csproj ../KarveWeb/
RUN dotnet restore ../KarveWeb/KarveWeb.csproj
COPY . .
WORKDIR /src/../KarveWeb
RUN dotnet build KarveWeb.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish KarveWeb.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "KarveWeb.dll"]
