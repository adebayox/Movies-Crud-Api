# Movies CRUD API built using C#/.Net

# API Collection Description

This API collection provides endpoints for managing movies. 
It offers various operations such as retrieving, adding, updating, and deleting movies.

Each movie has a model of name, description, release date, rating, ticket price, country, genre, photo.

The endpoints are as follows:

---

## API Endpoints

- **GET /api/Movie/GetAll**: Retrieve all movies.
- **DELETE /api/Movie/{id}**: Delete a specific movie by ID.
- **GET /api/Movie/{id}**: Retrieve details of a specific movie by ID.
- **POST /api/Movie/create-movie**: Create a new movie.
- **PUT /api/Movie/edit-movie**: Update an existing movie in the DB.

    

---

Please refer to the individual API endpoints for more detailed information on their usage, request parameters, and response formats.

## GET https://localhost:7208/api/Movie/GetAll
```
[https://localhost:7208/api/Movie/GetAll](https://localhost:7208/api/Movie/GetAll)
```

Description: Retrieves a list of all movies..

Method: GET

Returns: A list of all movies.

## POST https://localhost:7208/api/Movie/create-movie
```
[https://localhost:7208/api/Movie/create-movie](https://localhost:7208/api/Movie/create-movie)
```

Description: creates a new movie.

Method: POST

Request Body: Contains the necessary data to create a movie.
```
{
      "movieId": 2,
      "name": "koin koin",
      "description": "tragic",
      "rating": 4,
      "releaseDate": "0001-01-01T00:00:00",
      "ticketPrice": 200,
      "country": "canada",
      "genres": [],
      "photo": "string"
}
```

## GET https://localhost:7208/api/Movie/{id}
```
https://localhost:7208/api/Movie/{id}
```

Description: Retrieves detailed information about a movie based on its ID.

Method: GET

Route Parameter: movieID (int) - The movieId of the movie to retrieve.

## PUT https://localhost:7208/api/Movie/edit-movie
```
[https://localhost:7208/api/Movie/edit-movie](https://localhost:7208/api/Movie/edit-movie)
```

Description: Updates the details of a movie.

Method: PUT

Request Body: Contains the updated information for the movie.
```
{
      "movieId": 2,
      "name": "koin koin",
      "description": "tragic",
      "rating": 4,
      "releaseDate": "0001-01-01T00:00:00",
      "ticketPrice": 200,
      "country": "canada",
      "genres": [],
      "photo": "string"
}
```

## DELETE https://localhost:7208/api/Movie/{id}
```
https://localhost:7208/api/Movie/{id}
```

Description: Deletes a specific movie based on its movieID.

Method: DELETE

