#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Compras.Api/Compras.Api.csproj", "Compras.Api/"]
RUN dotnet restore "Compras.Api/Compras.Api.csproj"
COPY . .
WORKDIR "/src/Compras.Api"
RUN dotnet build "Compras.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Compras.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Compras.Api.dll"]