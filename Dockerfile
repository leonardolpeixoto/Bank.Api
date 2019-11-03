FROM mcr.microsoft.com/dotnet/core/sdk:2.2

WORKDIR /app

COPY . .

RUN dotnet restore
RUN dotnet build

EXPOSE 80
ENTRYPOINT [ "./entrypoint.sh" ]