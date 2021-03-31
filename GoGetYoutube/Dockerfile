#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
RUN apt-get update -y
RUN apt install python3 -y
RUN ln -s /usr/bin/python3 /usr/bin/python
RUN curl -L https://yt-dl.org/downloads/latest/youtube-dl -o /usr/local/bin/youtube-dl
RUN chmod a+rx /usr/local/bin/youtube-dl
RUN apt install ffmpeg -y
RUN apt install cifs-utils -y
RUN mkdir /mnt/NAS

WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["GoGetYoutube.csproj", "./"]
RUN dotnet restore "GoGetYoutube.csproj"
COPY . ./

WORKDIR /src/.
RUN dotnet build "GoGetYoutube.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GoGetYoutube.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GoGetYoutube.dll"]