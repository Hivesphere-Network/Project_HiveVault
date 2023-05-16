FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["/HiveVaultService/*.csproj", "HiveVaultService/"]
COPY ["/DataAccess/*.csproj", "DataAccess/"]

RUN dotnet restore "HiveVaultService/HiveVaultService.csproj"
COPY . .
WORKDIR "/src/HiveVaultService"
RUN dotnet dev-certs https
RUN dotnet build "HiveVaultService.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "HiveVaultService.csproj" -c Debug -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_ENVIRONMENT=Development
ENTRYPOINT ["dotnet", "HiveVaultService.dll"]