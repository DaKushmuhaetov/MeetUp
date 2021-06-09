#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/MeetUp.WebApi/MeetUp.WebApi.csproj", "src/MeetUp.WebApi/"]
RUN dotnet restore "src/MeetUp.WebApi/MeetUp.WebApi.csproj"
COPY . .
WORKDIR "/src/src/MeetUp.WebApi"
RUN dotnet build "MeetUp.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MeetUp.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MeetUp.WebApi.dll"]