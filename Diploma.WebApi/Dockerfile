#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Diploma.WebApi/Diploma.WebApi.csproj", "Diploma.WebApi/"]
COPY ["Diploma.Application/Diploma.Application.csproj", "Diploma.Application/"]
COPY ["Diploma.Domain/Diploma.Domain.csproj", "Diploma.Domain/"]
COPY ["Diploma.EmailSender/Diploma.EmailSender.csproj", "Diploma.EmailSender/"]
COPY ["Diploma.Persistence/Diploma.Persistence.csproj", "Diploma.Persistence/"]
RUN dotnet restore "Diploma.WebApi/Diploma.WebApi.csproj"
COPY . .
WORKDIR "/src/Diploma.WebApi"
RUN dotnet build "Diploma.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Diploma.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Diploma.WebApi.dll"]