dotnet restore
dotnet build -c release /nowarn:CS1591
dotnet publish -c release -o ./docker/build
docker build ./docker -t meetup
docker tag meetup danilkush/meetup:latest
docker push danilkush/meetup:latest

DEL "./docker/build" /S /Q