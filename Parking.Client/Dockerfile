FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Parking.Client/Parking.Client.csproj", "Parking.Client/"]
RUN dotnet restore "Parking.Client/Parking.Client.csproj"
COPY . .
WORKDIR "/src/Parking.Client"
RUN dotnet build "Parking.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Parking.Client.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Parking.Client.dll"]
