FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Api/Api.csproj", "Api/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["Core/Core.csproj", "Core/"]
COPY ["PagesResponses/PagesResponses.csproj", "PagesResponses/"]
COPY ["DataTransfer/DataTransfer.csproj", "DataTransfer/"]
RUN dotnet restore "Api/Api.csproj"
COPY . .
WORKDIR "/src/Api"
RUN dotnet build "Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]
