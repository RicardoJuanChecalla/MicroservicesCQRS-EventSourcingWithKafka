.NET Microservices CQRS & Event Sourcing with Kafka
https://campbelltech.io/courses

microservicesCQRS&Kafka

dotnet --version
docker --version
docker-compose --version
docker network create --attachable -d bridge mydockernetwork
docker network ls
docker-compose up -d
docker-compose down
docker ps

docker run -it -d --name mongo-container -p 27017:27017 --network mydockernetwork --restart always -v mongodb_data_container:/data/db mongo:latest

docker run -d --name sql-container --network mydockernetwork --restart always -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=$tr0ngS@P@ssw0rd02' -e 'MSSQL_PID=Express' -p 1433:1433 mcr.microsoft.com/mssql/server:2017-latest-ubuntu 

docker run -d --name posgres-container -p 5432:5432 --network mydockernetwork -e POSTGRES_PASSWORD=postgresPsw --restart always -v postgresql_data:/var/lib/postgresql/data postgres:latest

mkdir microservices-CQRS-Kafka
dotnet new sln
dotnet new classlib -o CQRS-ES/CQRS.Core
dotnet sln add CQRS-ES/CQRS.Core

dotnet new webapi -o SM-Post/Post.Cmd/Post.Cmd.Api
dotnet new classlib -o SM-Post/Post.Cmd/Post.Cmd.Domain
dotnet new classlib -o SM-Post/Post.Cmd/Post.Cmd.Infraestructure

dotnet new webapi -o SM-Post/Post.Query/Post.Query.Api
dotnet new classlib -o SM-Post/Post.Query/Post.Query.Domain
dotnet new classlib -o SM-Post/Post.Query/Post.Query.Infraestructure

dotnet new classlib -o SM-Post/Post.Common

dotnet sln add SM-Post/Post.Cmd/Post.Cmd.Api
dotnet sln add SM-Post/Post.Cmd/Post.Cmd.Domain
dotnet sln add SM-Post/Post.Cmd/Post.Cmd.Infraestructure

dotnet sln add SM-Post/Post.Query/Post.Query.Api
dotnet sln add SM-Post/Post.Query/Post.Query.Domain
dotnet sln add SM-Post/Post.Query/Post.Query.Infraestructure

dotnet sln add SM-Post/Post.Common

dotnet add SM-Post/Post.Cmd/Post.Cmd.Api/Post.Cmd.Api.csproj reference CQRS-ES/CQRS.Core/CQRS.Core.csproj
dotnet add SM-Post/Post.Cmd/Post.Cmd.Api/Post.Cmd.Api.csproj reference SM-Post/Post.Cmd/Post.Cmd.Domain/Post.Cmd.Domain.csproj
dotnet add SM-Post/Post.Cmd/Post.Cmd.Api/Post.Cmd.Api.csproj reference SM-Post/Post.Cmd/Post.Cmd.Infraestructure/Post.Cmd.Infraestructure.csproj
dotnet add SM-Post/Post.Cmd/Post.Cmd.Api/Post.Cmd.Api.csproj reference SM-Post/Post.Common/Post.Common.csproj

dotnet add SM-Post/Post.Cmd/Post.Cmd.Domain/Post.Cmd.Domain.csproj reference CQRS-ES/CQRS.Core/CQRS.Core.csproj
dotnet add SM-Post/Post.Cmd/Post.Cmd.Domain/Post.Cmd.Domain.csproj reference SM-Post/Post.Common/Post.Common.csproj

dotnet add SM-Post/Post.Cmd/Post.Cmd.Infraestructure/Post.Cmd.Infraestructure.csproj reference CQRS-ES/CQRS.Core/CQRS.Core.csproj
dotnet add SM-Post/Post.Cmd/Post.Cmd.Infraestructure/Post.Cmd.Infraestructure.csproj reference SM-Post/Post.Cmd/Post.Cmd.Domain/Post.Cmd.Domain.csproj
------------------------------------------------------------------------------------------------------------------------------------------------
dotnet add SM-Post/Post.Common/Post.Common.csproj reference CQRS-ES/CQRS.Core/CQRS.Core.csproj
------------------------------------------------------------------------------------------------------------------------------------------------
dotnet add SM-Post/Post.Query/Post.Query.Api/Post.Query.Api.csproj reference CQRS-ES/CQRS.Core/CQRS.Core.csproj
dotnet add SM-Post/Post.Query/Post.Query.Api/Post.Query.Api.csproj reference SM-Post/Post.Query/Post.Query.Domain/Post.Query.Domain.csproj
dotnet add SM-Post/Post.Query/Post.Query.Api/Post.Query.Api.csproj reference SM-Post/Post.Query/Post.Query.Infraestructure/Post.Query.Infraestructure.csproj
dotnet add SM-Post/Post.Query/Post.Query.Api/Post.Query.Api.csproj reference SM-Post/Post.Common/Post.Common.csproj

dotnet add SM-Post/Post.Query/Post.Query.Domain/Post.Query.Domain.csproj reference CQRS-ES/CQRS.Core/CQRS.Core.csproj
dotnet add SM-Post/Post.Query/Post.Query.Domain/Post.Query.Domain.csproj reference SM-Post/Post.Common/Post.Common.csproj

dotnet add SM-Post/Post.Query/Post.Query.Infraestructure/Post.Query.Infraestructure.csproj reference CQRS-ES/CQRS.Core/CQRS.Core.csproj
dotnet add SM-Post/Post.Query/Post.Query.Infraestructure/Post.Query.Infraestructure.csproj reference SM-Post/Post.Query/Post.Query.Domain/Post.Query.Domain.csproj

------------------------------------------------------------------------------------------------------------------------------------------------
dotnet add ./CQRS-ES/CQRS.Core/CQRS.Core.csproj package MongoDB.Driver --version 2.19.1
dotnet add ./SM-Post/Post.Cmd/Post.Cmd.Infraestructure/Post.Cmd.Infraestructure.csproj package MongoDB.Driver --version 2.19.1
dotnet add ./SM-Post/Post.Cmd/Post.Cmd.Infraestructure/Post.Cmd.Infraestructure.csproj package Confluent.Kafka --version 2.1.0
dotnet add ./SM-Post/Post.Cmd/Post.Cmd.Infraestructure/Post.Cmd.Infraestructure.csproj package Microsoft.Extensions.Options --version 7.0.1

dotnet add ./SM-Post/Post.Query/Post.Query.Infraestructure/Post.Query.Infraestructure.csproj package Microsoft.EntityFrameworkCore.SqlServer --version 7.0.5
dotnet add ./SM-Post/Post.Query/Post.Query.Infraestructure/Post.Query.Infraestructure.csproj package Microsoft.EntityFrameworkCore.Proxies --version 7.0.5
dotnet add ./SM-Post/Post.Query/Post.Query.Infraestructure/Post.Query.Infraestructure.csproj package Npgsql.EntityFrameworkCore.PostgreSQL --version 7.0.3
dotnet add ./SM-Post/Post.Query/Post.Query.Infraestructure/Post.Query.Infraestructure.csproj package Microsoft.Extensions.Hosting --version 7.0.1
dotnet add ./SM-Post/Post.Query/Post.Query.Infraestructure/Post.Query.Infraestructure.csproj package Confluent.Kafka --version 2.1.0

dotnet add ./SM-Post/Post.Query/Post.Query.Api/Post.Query.Api.csproj package Microsoft.EntityFrameworkCore.SqlServer --version 7.0.5
------------------------------------------------------------------------------------------------------------------------------------------------
dotnet restore ./CQRS-ES/CQRS.Core/CQRS.Core.csproj
dotnet build ./CQRS-ES/CQRS.Core/CQRS.Core.csproj
dotnet run --project ./CQRS-ES/CQRS.Core/CQRS.Core.csproj

dotnet restore ./SM-Post/Post.Cmd/Post.Cmd.Api/Post.Cmd.Api.csproj
dotnet build ./SM-Post/Post.Cmd/Post.Cmd.Api/Post.Cmd.Api.csproj
dotnet run --project ./SM-Post/Post.Cmd/Post.Cmd.Api/Post.Cmd.Api.csproj

dotnet restore ./SM-Post/Post.Query/Post.Query.Api/Post.Query.Api.csproj
dotnet build ./SM-Post/Post.Query/Post.Query.Api/Post.Query.Api.csproj
dotnet run --project ./SM-Post/Post.Query/Post.Query.Api/Post.Query.Api.csproj

dotnet restore ./SM-Post/Post.Cmd/Post.Cmd.Domain/Post.Cmd.Domain.csproj
dotnet build ./SM-Post/Post.Cmd/Post.Cmd.Domain/Post.Cmd.Domain.csproj
dotnet run --project ./SM-Post/Post.Cmd/Post.Cmd.Domain/Post.Cmd.Domain.csproj

dotnet restore ./SM-Post/Post.Cmd/Post.Cmd.Infraestructure/Post.Cmd.Infraestructure.csproj
dotnet build ./SM-Post/Post.Cmd/Post.Cmd.Infraestructure/Post.Cmd.Infraestructure.csproj
dotnet run --project ./SM-Post/Post.Cmd/Post.Cmd.Infraestructure/Post.Cmd.Infraestructure.csproj

dotnet restore ./SM-Post/Post.Query/Post.Query.Infraestructure/Post.Query.Infraestructure.csproj
dotnet build ./SM-Post/Post.Query/Post.Query.Infraestructure/Post.Query.Infraestructure.csproj
dotnet run --project ./SM-Post/Post.Query/Post.Query.Infraestructure/Post.Query.Infraestructure.csproj

