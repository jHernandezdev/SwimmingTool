FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
EXPOSE 80
EXPOSE 443

WORKDIR /app
COPY /SwimmingTool_LatestBuild .
ENTRYPOINT ["dotnet", "SwimmingTool.Api.dll"]
