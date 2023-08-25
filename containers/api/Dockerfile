#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/SwimmingTool.Api/SwimmingTool.Api.csproj", "src/SwimmingTool.Api/"]
COPY ["src/SwimmingTool.Application/SwimmingTool.Application.csproj", "src/SwimmingTool.Application/"]
COPY ["src/SwimmingTool.Domain/SwimmingTool.Domain.csproj", "src/SwimmingTool.Domain/"]
COPY ["src/SwimmingTool.Infrastructure/SwimmingTool.Infrastructure.csproj", "src/SwimmingTool.Infrastructure/"]
RUN dotnet restore "src/SwimmingTool.Api/SwimmingTool.Api.csproj"
COPY . .
WORKDIR "/src/SwimmingTool.Api"
RUN dotnet build "SwimmingTool.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SwimmingTool.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SwimmingTool.Api.dll"]
