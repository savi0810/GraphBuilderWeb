FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /source

COPY GraphBuilderFrontend/*.csproj ./GraphBuilderFrontend/
COPY GraphBuilderShared/*.csproj ./GraphBuilderShared/

RUN dotnet restore ./GraphBuilderFrontend/GraphBuilderFrontend.csproj

COPY . .

RUN dotnet publish ./GraphBuilderFrontend/GraphBuilderFrontend.csproj -c Release -o /app/publish

FROM nginx:alpine
COPY --from=build /app/publish/wwwroot /usr/share/nginx/html
COPY GraphBuilderFrontend/nginx.conf /etc/nginx/nginx.conf
EXPOSE 3000
CMD ["nginx", "-g", "demon off;"]