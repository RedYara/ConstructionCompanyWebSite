# Этап 1: Базовый образ
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Этап 2: Сборка
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Копируем файлы проекта
COPY ["Web/Web.csproj", "Web/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["EmailSender/EmailSender.csproj", "EmailSender/"]
COPY ["Persistence/Persistence.csproj", "Persistence/"]

RUN dotnet restore "Web/Web.csproj"

COPY . .

# Публикуем приложение
FROM build AS publish
RUN dotnet publish "Web/Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Этап 3: Финальный образ
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Web.dll"]
