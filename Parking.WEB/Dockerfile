FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Parking.WEB/Parking.WEB.csproj", "Parking.WEB/"]
RUN dotnet restore "Parking.WEB/Parking.WEB.csproj"
COPY . .
WORKDIR "/src/Parking.WEB"
RUN dotnet build "Parking.WEB.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Parking.WEB.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Parking.WEB.dll"]
