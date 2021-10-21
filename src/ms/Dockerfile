FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore src/ms/ms.csproj

WORKDIR "/src/src/ms"
RUN dotnet build ms.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ms.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ms.dll"]
