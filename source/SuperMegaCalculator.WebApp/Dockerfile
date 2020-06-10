FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

ARG BUILDCONFIG=RELEASE
ARG VERSION=1.0.0.0

COPY SuperMegaCalculator.WebApp.csproj /build/

RUN dotnet restore ./build/SuperMegaCalculator.WebApp.csproj

COPY . ./build/
WORKDIR /build/
RUN dotnet publish ./SuperMegaCalculator.WebApp.csproj -c $BUILDCONFIG -o out /p:version=$VERSION

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 80
COPY --from=build /build/out .
ENTRYPOINT ["dotnet", "SuperMegaCalculator.WebApp.dll"]