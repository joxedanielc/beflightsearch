# beflightsearch
This project is a RESTful API service to get information from flights.

## Features  

- Creates tables and seed them
- Get all flights, flight by id and creates flight

# Table of contents  
1. [Tech Stack](https://github.com/joxedanielc/github-timeline-api#tech-stack)  
2. Code Explanation
    1. [API](https://github.com/joxedanielc/github-timeline-api#api)
    2. [Utils](https://github.com/joxedanielc/github-timeline-api#utils)
4. [Run Locally](https://github.com/joxedanielc/github-timeline-api#run-locally)  
5. [Feedback](https://github.com/joxedanielc/github-timeline-api#feedback)
6. [License](https://github.com/joxedanielc/github-timeline-api#license)

## Tech Stack  

- .Net Core
- Swagger

## Code Explanation  

Controllers handle incoming HTTP requests and send responses. Each controller is associated with a specific route (endpoint) and has methods that correspond to HTTP verbs (GET, POST).

In services we can find the business logic of the application. They handle tasks like data validation & database interactions.

## Run Locally  

### Important: 

Clone the project  

~~~bash  
  git clone https://github.com/joxedanielc/beflightsearch.git
~~~

Go to the project directory  

~~~bash  
cd beflightsearch
~~~

Run migrations

~~~bash  
dotnet ef database update
~~~

**Update CORS origins in file Program.cs**

Once you lift `feflightsearch`, you will get the port where is applications is running.
You will need to update the port in `WithOrigins` so the BE allows calls.

~~~bash  
app.UseCors(builder => builder
    .WithOrigins("http://localhost:portToUpdated"));
~~~

Run the application :rocket:

## Feedback  

If you have any feedback, please leave a comment.

## License  

[MIT](https://choosealicense.com/licenses/mit/)
