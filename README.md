### Lab 14 :Tunify Platform
# Tunify Platform
Tunify Platform is a dynamic web application designed to enhance your music experience by providing a comprehensive solution for managing and streaming your favorite tunes. Built on .NET Core, Tunify seamlessly integrates with a robust SQL Server database to offer an efficient and scalable platform for music enthusiasts.

The application leverages Entity Framework Core for database management, enabling smooth interactions with your data through well-defined models and relationships. With Tunify, users can create and manage playlists, explore songs and albums, follow artists, and subscribe to various music plans, all within a user-friendly interface.

# Entity Relationships Overview
User: Each user can create multiple playlists and subscribe to different music plans.

Playlist: Playlists are collections of songs created by users. Each playlist can contain multiple songs, and each song can be part of multiple playlists (many-to-many relationship through the PlaylistSongs table).

Song: Songs are the core of the music library. Each song belongs to an album and can be part of multiple playlists.

Artist: Artists create songs and albums. Each artist can have multiple albums, and each album belongs to one artist.

Album: Albums are collections of songs by an artist. Each album can contain multiple songs.

Subscription: Subscriptions link users to different service tiers, offering various levels of access to the music library.

# ERD :
![ERD](TunifyPlatform/assets/Tunify.png)

# Explaining the Repository Design Pattern and its benefits
The Repository Design Pattern is a design pattern that acts as a middle layer between the data access layer and the business logic layer in an application. Its primary purpose is to isolate the data access logic and encapsulate it in a repository, making it easier to manage and maintain and making your application more modular and testable.

### Benefits of Repository Design Pattern
1) Hide the complexty and details of the data access layer from business logic layer

2) Code becomes easier to maintain and modify

3) Makes the code more testable by isolating the data access layer

4) Making the code resuable accoss diffrent parts of the application

5) Switching the data storage solutions: like sql server or database in memory



### Lab 13: Tunify Platform - Navigation and Routing
# ERD Output :
![c](https://github.com/user-attachments/assets/a6c184ed-9ed6-4a75-b8d2-74d66b37b337)



### Lab 14 :Tunify Platform - Swagger UI Integration


In this lab, Swagger UI was added to the Tunify Platform to automatically generate and visualize the API documentation. This makes it easier for developers to understand, test, and interact with the API endpoints.


### Lab 15 :Tunify Platform - Identity 


In this lab, you'll add authentication to the Tunify Platform using ASP.NET Core Identity. You'll configure Identity services, allowing users to register, log in, and log out.

