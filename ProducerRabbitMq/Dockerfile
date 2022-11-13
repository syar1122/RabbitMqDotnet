FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ProducerRabbitMq.csproj", "./"]
RUN dotnet restore "ProducerRabbitMq.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "ProducerRabbitMq.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProducerRabbitMq.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProducerRabbitMq.dll"]
