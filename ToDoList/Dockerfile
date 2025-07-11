# Etapa base (para execução da aplicação)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Etapa de build (compilar e publicar)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia o csproj e restaura
COPY ToDoList.csproj ./
RUN dotnet restore ToDoList.csproj

# Copia todo o código
COPY . ./
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ToDoList.dll"]
