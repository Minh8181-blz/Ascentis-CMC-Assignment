#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Web1/DeviceManager.Presentation.Web.csproj", "Web1/"]
COPY ["DeviceManager.Utilities/DeviceManager.Utilities.csproj", "DeviceManager.Utilities/"]
COPY ["DeviceManager.Business/DeviceManager.Business.csproj", "DeviceManager.Business/"]
COPY ["DeviceManager.DataAccess/DeviceManager.DataAccess.csproj", "DeviceManager.DataAccess/"]
RUN dotnet restore "Web1/DeviceManager.Presentation.Web.csproj"
COPY . .
WORKDIR "/src/Web1"
RUN dotnet build "DeviceManager.Presentation.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DeviceManager.Presentation.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DeviceManager.Presentation.Web.dll"]