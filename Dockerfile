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
RUN dotnet dev-certs https && dotnet build "HiveVaultService.csproj" -c Release -o /app/build 

FROM build AS publish
RUN dotnet publish "HiveVaultService.csproj" -c Release -o /app/publish /p:UseAppHost=false

ENV ASPNETCORE_ENVIRONMENT=Development
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "HiveVaultService.dll"]