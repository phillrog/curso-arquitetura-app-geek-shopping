#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 57065

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["services/GeekShopping.ProductAPI/GeekShopping.ProductAPI.csproj", "services/GeekShopping.ProductAPI/"]
RUN dotnet restore "services/GeekShopping.ProductAPI/GeekShopping.ProductAPI.csproj"
COPY . .
WORKDIR "/src/services/GeekShopping.ProductAPI"
RUN dotnet build "GeekShopping.ProductAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GeekShopping.ProductAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GeekShopping.ProductAPI.dll"]