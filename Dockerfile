#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
# HTTP
EXPOSE 8080
# HTTPS
EXPOSE 8081


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
ARG TARGETPLATFORM

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
RUN case ${TARGETPLATFORM} in \
        "linux/amd64") RID="linux-x64" ;; \
        "linux/arm64") RID="linux-arm64" ;; \
        *) echo "Unsupported architecture: ${TARGETPLATFORM}" >&2; exit 1 ;; \
    esac && \
    dotnet ef migrations bundle \
        --runtime ${RID} \
        -p "./Tabi.csproj" \
        -o /app/efbundle


FROM scratch AS bundle-export
COPY --from=build /app/efbundle /efbundle


FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Tabi.dll"]