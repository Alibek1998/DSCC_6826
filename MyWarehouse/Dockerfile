FROM microsoft/aspnetcore:2.0-stretch AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-stretch AS build
WORKDIR /src
COPY ["MyWarehouse/MyWarehouse.csproj", "MyWarehouse/"]
RUN dotnet restore "MyWarehouse/MyWarehouse.csproj"
COPY . .
WORKDIR "/src/MyWarehouse"
RUN dotnet build "MyWarehouse.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MyWarehouse.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MyWarehouse.dll"]