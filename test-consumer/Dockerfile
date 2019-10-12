FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["test-consumer/test-consumer.csproj", "test-consumer/"]
RUN dotnet restore "test-consumer/test-consumer.csproj"
COPY . .
WORKDIR "/src/test-consumer"
RUN dotnet build "test-consumer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "test-consumer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "test-consumer.dll"]