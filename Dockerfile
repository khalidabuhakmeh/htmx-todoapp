FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["htmx-todoapp.csproj", "./"]
RUN dotnet restore "htmx-todoapp.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "htmx-todoapp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "htmx-todoapp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "htmx-todoapp.dll"]
