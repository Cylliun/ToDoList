# Usando o SDK do .NET para buildar o projeto
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY . .

RUN dotnet restore
RUN dotnet publish -c Release -o /app

# Imagem para execução da API
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app .

# Porta que a API usa
EXPOSE 7201

ENTRYPOINT ["dotnet", "ToDoList"]
