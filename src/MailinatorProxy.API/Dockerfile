FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 7291

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/MailinatorProxy.API/MailinatorProxy.API.csproj", "src/MailinatorProxy.API/"]
RUN dotnet restore "src/MailinatorProxy.API/MailinatorProxy.API.csproj"
COPY . .
WORKDIR "/src/src/MailinatorProxy.API"
RUN dotnet build "MailinatorProxy.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MailinatorProxy.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MailinatorProxy.API.dll"]
