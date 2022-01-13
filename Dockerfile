# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build-env
WORKDIR /dotNetEndpoint

RUN apt-get install -y git

ARG REVDEBUG_RECORD_SERVER_ADDRESS
ENV REVDEBUG_RECORD_SERVER_ADDRESS=$REVDEBUG_RECORD_SERVER_ADDRESS

ARG REVDEBUG_DOTNET_COMPILER_VERSION=6.1.17
ENV REVDEBUG_DOTNET_COMPILER_VERSION=$REVDEBUG_DOTNET_COMPILER_VERSION

ARG REVDEBUG_DOTNET_AGENT_VERSION=6.1.19
ENV REVDEBUG_DOTNET_AGENT_VERSION=$REVDEBUG_DOTNET_AGENT_VERSION

ARG REVDEBUG_TLSARGS
ENV REVDEBUG_TLS=$REVDEBUG_TLSARGS

ARG REVDEBUG_ACTIVEARG
ENV REVDEBUG_ACTIVE=$REVDEBUG_ACTIVEARG

ARG SW_AGENT_ACTIVE_ARG
ENV SW_ACTIVE=$SW_AGENT_ACTIVE_ARG

COPY . ./
RUN dotnet nuget add source https://nexus.revdebug.com/repository/nuget --name rdb_nexus
RUN dotnet nuget add source https://nexus-test.revdebug.com/repository/nuget --name rdb_nexus_test
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:3.1


ARG REVDEBUG_ACTIVE=true
ENV REVDEBUG_ACTIVE='$REVDEBUG_ACTIVE'

ARG SW_AGENT_ACTIVE_ARG=true
ENV SW_ACTIVE='$SW_AGENT_ACTIVE_ARG'


WORKDIR /dotNetEndpoint
COPY --from=build-env /dotNetEndpoint/out .
ENV ASPNETCORE_HOSTINGSTARTUPASSEMBLIES=RevDeBugAPM.Agent.AspNetCore
RUN cat skyapm.json

ENTRYPOINT ["dotnet", "dotNetEndpoint.dll"]
