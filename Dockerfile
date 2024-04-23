FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy all to builder
COPY . /app/.

# Set dir app path
WORKDIR /app/src/Payments.Api

# Compile
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
RUN apt-get update \
    && apt-get install -y --no-install-recommends libgdiplus libc6-dev \
    && apt-get clean \
    && rm -rf /var/lib/apt/lists/*
WORKDIR /app

EXPOSE 5088

ENV ASPNETCORE_URLS=http://+:5088

COPY --from=build-env /app/src/Payments.Api/out .

ENTRYPOINT dotnet Payments.Api.dll

