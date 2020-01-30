FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Codescu.IDP.STS.Identity/Codescu.IDP.STS.Identity.csproj", "src/Codescu.IDP.STS.Identity/"]
COPY ["src/Codescu.IDP.Admin.EntityFramework.Shared/Codescu.IDP.Admin.EntityFramework.Shared.csproj", "src/Codescu.IDP.Admin.EntityFramework.Shared/"]
COPY ["src/Codescu.IDP.Admin.EntityFramework.SqlServer/Codescu.IDP.Admin.EntityFramework.SqlServer.csproj", "src/Codescu.IDP.Admin.EntityFramework.SqlServer/"]
COPY ["src/Codescu.IDP.Admin.EntityFramework.PostgreSQL/Codescu.IDP.Admin.EntityFramework.PostgreSQL.csproj", "src/Codescu.IDP.Admin.EntityFramework.PostgreSQL/"]
COPY ["src/Codescu.IDP.Admin.EntityFramework.MySql/Codescu.IDP.Admin.EntityFramework.MySql.csproj", "src/Codescu.IDP.Admin.EntityFramework.MySql/"]
RUN dotnet restore "src/Codescu.IDP.STS.Identity/Codescu.IDP.STS.Identity.csproj"
COPY . .
WORKDIR "/src/src/Codescu.IDP.STS.Identity"
RUN dotnet build "Codescu.IDP.STS.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Codescu.IDP.STS.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "Codescu.IDP.STS.Identity.dll"]