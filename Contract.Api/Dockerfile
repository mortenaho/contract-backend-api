FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Contract/Contract.csproj", "Contract/"]
RUN dotnet restore "Contract/Contract.csproj"
COPY . .
WORKDIR "/src/Contract"
RUN dotnet build "Contract.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Contract.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Contract.dll"]
