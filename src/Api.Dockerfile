FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine3.15-amd64 AS base
WORKDIR /app
EXPOSE 5001/tcp

RUN apk add libgdiplus --update-cache --repository http://dl-3.alpinelinux.org/alpine/edge/testing/ --allow-untrusted && \
    apk add terminus-font && \
    apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT false
ENV ASPNETCORE_ENVIRONMENT=Production
#ENV ConnectionStrings:PosterrChatConnection="server=posterr-db;database=posterr;user=sa;password=dev@1234;convert zero datetime=True;"s

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine3.15-amd64 AS build-env
COPY ["./Posterr.sln", "./"]
COPY ["./Posterr.Bot/Posterr.Bot.csproj", "./Posterr.Bot/" ]
COPY ["./Posterr.Shared.Kernel/Posterr.Shared.Kernel.csproj", "./Posterr.Shared.Kernel/" ]
COPY ["./Posterr.Infrastructure/Posterr.Infrastructure.csproj", "./Posterr.Infrastructure/" ]
COPY ["./Posterr.Domain/Posterr.Domain.csproj", "./Posterr.Domain/" ]
COPY ["./Posterr.Application/Posterr.Application.csproj", "./Posterr.Application/" ]
COPY ["./Posterr.Api/Posterr.Api.csproj", "./Posterr.Api/" ]
#RUN dotnet restore "./Posterr.Api/Posterr.Api.csproj"
COPY ./ .

#RUN dotnet build "./Posterr.Api/Posterr.Api.csproj" --packages ./.nuget/packages -c Production -o /app/build

#RUN dotnet test

FROM build-env AS publish
RUN dotnet publish "./Posterr.Api/Posterr.Api.csproj" -c Production -o /app/publish


FROM base AS final
WORKDIR /app/build
RUN chmod +x ./

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Posterr.Api.dll", "--server.urls", "http://*:5001"]