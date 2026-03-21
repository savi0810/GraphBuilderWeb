FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /source

COPY GraphBuilderWeb/*.csproj ./GraphBuilderWeb/
COPY GraphBuilderShared/*.csproj ./GraphBuilderShared/

RUN dotnet restore ./GraphBuilderWeb/GraphBuilderWeb.csproj

COPY . .

RUN dotnet publish ./GraphBuilderWeb/GraphBuilderWeb.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:9.0
EXPOSE 8000
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "GraphBuilderWeb.dll"]