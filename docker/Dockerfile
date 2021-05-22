FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /eventos

COPY *.sln ./

COPY src/Eventos.Api/Eventos.Api.csproj src/Eventos.Api/
COPY src/Eventos.Application/Eventos.Application.csproj src/Eventos.Application/
COPY src/Eventos.Core/Eventos.Core.csproj src/Eventos.Core/
COPY src/Eventos.Infrastructure/Eventos.Infrastructure.csproj src/Eventos.Infrastructure/
COPY src/Eventos.Shared/Eventos.Shared.csproj src/Eventos.Shared/
COPY test/Eventos.Tests/Eventos.Tests.csproj test/Eventos.Tests/

RUN dotnet restore

COPY . .

WORKDIR /eventos/src/Eventos.Api/
RUN dotnet build --configuration Release --output /app

FROM build AS publish

RUN dotnet publish --configuration Release --output /app --no-restore

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app

COPY --from=publish /app .

ENTRYPOINT ["dotnet", "./Eventos.Api.dll"]
