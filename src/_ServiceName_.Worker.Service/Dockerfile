FROM microsoft/dotnet:2.1-runtime AS base
WORKDIR /app

# Copy csproj and restore distinct layers
FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY . .
RUN dotnet restore src/_ServiceName_.Worker.Service/_ServiceName_.Worker.Service.csproj
RUN dotnet build src/_ServiceName_.Worker.Service/_ServiceName_.Worker.Service.csproj -c Release -o /app

FROM build as publish
RUN dotnet publish -c Release -o /app

FROM base as final
ENV EnvironmentName=Local
ENV AiInstrumentationKey=MissingInstrumentationKey
ENV RunningDocker=true
ENV ServiceBusConnectionString=MissingServiceBusConnectionString
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "UmbracoCloud._BoundedContext_._ServiceName_.Worker.Service.dll"]

# Copy csproj and restore distinct layers



#FROM microsoft/dotnet:2.1-sdk AS build
#WORKDIR /app
#COPY _ServiceName_.Worker.Service/_ServiceName_.Worker.Service.csproj _ServiceName_.Worker.Service/
#RUN dotnet restore _ServiceName_.Worker.Service/_ServiceName_.Worker.Service.csproj
#COPY . .
#WORKDIR /src/_ServiceName_.Worker.Service
#RUN dotnet build _ServiceName_.Worker.Service.csproj -c Release -o /app

#FROM build AS publish
#RUN dotnet publish _ServiceName_.Worker.Service.csproj -c Release -o /app

#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app .
#ENTRYPOINT ["dotnet", "_ServiceName_.Worker.Service.dll"]