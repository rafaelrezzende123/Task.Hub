FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["src/Task.Hub.Web/Task.Hub.Web.csproj", "src/Task.Hub.Web/"]
COPY ["src/Task.Hub.Infrastructure/Task.Hub.Infrastructure.csproj", "src/Task.Hub.Infrastructure/"]
COPY ["src/Task.Hub.Core/Task.Hub.Core.csproj", "src/Task.Hub.Core/"]
COPY ["src/Task.Hub.UseCases/Task.Hub.UseCases.csproj", "src/Task.Hub.UseCases/"]
RUN dotnet restore "./src/Task.Hub.Web/Task.Hub.Web.csproj"
COPY . .
WORKDIR "/src/src/Task.Hub.Web"
RUN dotnet build "./Task.Hub.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Task.Hub.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Task.Hub.Web.dll"]