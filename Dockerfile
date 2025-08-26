FROM mcr.microsoft.com/playwright/dotnet:v1.54.0-noble AS build-env

# Install .NET 9 SDK
RUN curl -sSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --install-dir /usr/share/dotnet --channel 9.0

# restore, build & test
WORKDIR /app
COPY . ./   
RUN dotnet restore && dotnet build --no-restore -c Release && dotnet test --no-build -c Release || true

# Create artifacts directory
RUN mkdir -p /artifacts

# Copy the test report to the artifacts directory
RUN cp specs/SpecificationByExample.Specifications/bin/Debug/net9.0/bdd-report.html /artifacts/index.html

# Copy screenshots to the artifacts directory
RUN cp specs/SpecificationByExample.Specifications/bin/Debug/net9.0/*.png /artifacts/