FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["InTheCatsPaws/InTheCatsPaws.csproj", "InTheCatsPaws/"]
RUN dotnet restore "InTheCatsPaws/InTheCatsPaws.csproj"
COPY . .
WORKDIR "/src/InTheCatsPaws"
RUN dotnet build "InTheCatsPaws.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InTheCatsPaws.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InTheCatsPaws.dll"]
