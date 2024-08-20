FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Contract.UI/Contract.UI.csproj", "Contract.UI/"]
RUN dotnet restore "Contract.UI/Contract.UI.csproj"
COPY . .
WORKDIR "/src/Contract.UI"
RUN dotnet build "Contract.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Contract.UI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Contract.UI.dll"]
