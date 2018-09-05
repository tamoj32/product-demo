# Product Sample

This project is to demonstrate the implemenation of a RESTful web api that performs CRUD operations using Web API 2 framework. 

This project uses EntityFramework Core in-memory Persistance to store data and also demonstrated in Unit Testing. 

Swagger is used for a light weight UI for querying the API

This project also demonstrate the use of custom jwt authentication and claim based authorization.

To generate token, POST as x-www-form-urlencoded

URL: http://localhost:57365/api/token

Body: 

grant_type: password

username: admin

password: admin123 

Tools: https://www.getpostman.com/

To view API, 

URL: http://localhost:50050/swagger

To query API, use Authorization value "Bearer <jwt token>"
  
To run Web API, Set Startup Projects as Account.TokenProvider.API, ProductService.API to start  
