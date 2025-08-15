FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release

# Install EF Core
RUN dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"

WORKDIR /src
COPY ["Tabi/Tabi.csproj", "Tabi/"]
RUN dotnet restore "./Tabi/Tabi.csproj"

COPY . .
WORKDIR "/src/Tabi"

RUN dotnet build "./Tabi.csproj" -c $BUILD_CONFIGURATION -o /app/build
RUN dotnet publish "./Tabi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Generate migrations bundle for specific architecture
FROM build AS migrations-bundle
ARG TARGETPLATFORM
RUN dotnet ef migrations bundle -p "./Tabi.csproj" -o /app/efbundle

FROM scratch AS bundle-export
COPY --from=migrations-bundle /app/efbundle /efbundle


FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
USER app
WORKDIR /app
COPY --from=build /app/publish .

# HTTP
EXPOSE 8080
# HTTPS
EXPOSE 8081
ENTRYPOINT ["dotnet", "Tabi.dll"]
