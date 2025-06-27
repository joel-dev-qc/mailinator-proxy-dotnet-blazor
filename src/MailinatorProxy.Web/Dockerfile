FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["src/MailinatorProxy.Web/MailinatorProxy.Web.csproj", "src/MailinatorProxy.Web/"]
COPY ["src/MailinatorProxy.Shared/MailinatorProxy.Shared.csproj", "src/MailinatorProxy.Shared/"]
RUN dotnet restore "src/MailinatorProxy.Web/MailinatorProxy.Web.csproj"
COPY . .
WORKDIR "/src/src/MailinatorProxy.Web"
RUN dotnet build "MailinatorProxy.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MailinatorProxy.Web.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY docker/nginx/nginx.conf /etc/nginx/nginx.conf
EXPOSE 80
