#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Hahn.Application.Web/Hahn.Application.Web.csproj", "Hahn.Application.Web/"]
COPY ["Hahn.Application.DAL/Hahn.Application.DAL.csproj", "Hahn.Application.DAL/"]
COPY ["Hahn.Application.Domain/Hahn.Application.Domain.csproj", "Hahn.Application.Domain/"]
RUN dotnet restore "Hahn.Application.Web/Hahn.Application.Web.csproj"
COPY . .
WORKDIR "/src/Hahn.Application.Web"
RUN dotnet build "Hahn.Application.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hahn.Application.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hahn.Application.Web.dll"]
