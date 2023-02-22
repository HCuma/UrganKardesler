#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["UrganKardesler/UrganKardesler.csproj", "UrganKardesler/"]
RUN dotnet restore "UrganKardesler/UrganKardesler.csproj"
COPY . .
WORKDIR "/src/UrganKardesler"
RUN dotnet build "UrganKardesler.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UrganKardesler.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UrganKardesler.dll"]