# Etapa base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia o .csproj e restaura os pacotes
COPY ToDoList/ToDoList.csproj ./ToDoList/
RUN dotnet restore ./ToDoList/ToDoList.csproj

# Copia o restante do código
COPY ToDoList/. ./ToDoList/
WORKDIR /src/ToDoList
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ToDoList.dll"]