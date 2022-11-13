FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Consummer.RabbitMq.csproj", "./"]
RUN dotnet restore "Consummer.RabbitMq.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "Consummer.RabbitMq.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Consummer.RabbitMq.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Consummer.RabbitMq.dll"]
