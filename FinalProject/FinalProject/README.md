### UPSCHOOL FINAL PROJECT (BACKEND PART)

 ###   Overview
 This project was created upon the need of a customer who wants to follow the products on the rival company's website. What is done in the project is to pull the competitor's products according to the filters requested by the customer and transfer them to the ui layer in real time.
 
 ###   My Project Design
 
 
The project consists of 3 parts. Interactions between projects are shown in the diagram.


![project](https://github.com/Merve-Albayrak/UpSchool-FullStack-Development-Bootcamp/assets/63204791/b225302e-2052-4d7b-a2e4-0f18914d505c)


Let's take a closer look at the details of the projects and the technologies and libraries used.


 ###   1. CRAWLER APP
 
 
 In this project, the competitor's website is being examined. The necessary product information is pulled from the site using Selenium. Then, by making a request to the apiye, the products and order information
is saved in the database. During all these processes, at what stage the order is, what is the status of the scraping process, what are the products found and similar information is instantly transmitted to the web side using SignalR.


![image](https://github.com/Merve-Albayrak/UpSchool-FullStack-Development-Bootcamp/assets/63204791/9f98235f-4e1b-4c1b-ac35-0572a2d83694)


### Technologies and libraries used in the project:

### 1-) Selenium


Selenium is a free (open-source) automated testing framework used to validate web applications across different browsers and platforms. You can use multiple programming languages like Java, C#, Python, etc to create Selenium Test Scripts. Testing done using the Selenium testing tool is usually referred to as Selenium Testing.


### 2) SignalR



We know very well how a client sends data to a server so now it's time to understand how a server pushes data to a client in a HTTP connection. SignalR is an open source library to add real-time web functionality in your ASP.Net web application.

So what does real-time functionality mean? Just use as an example when more than 1 user is working on the same document in Google Documents When a user is making changes and at the same time another user can see the changes without reloading the page. So real-time web functionality is the ability to have server code to push content to connected clients. In the HTTP request response model we know each time we need to send a new request to communicate with the server but SignalR provides a persistent connection between the client and server.


![image](https://github.com/Merve-Albayrak/UpSchool-FullStack-Development-Bootcamp/assets/63204791/b3157abb-7086-4fe0-8713-47a438c7c239)


 ###   2. WEB API
 

 This part is responsible for meeting incoming requests. It saves the incoming data to the database.
 
  The SignalR hub is also located here.
 CQRS pattern and Clean Architecture are used in the API project.
 
 

### Technologies  used in the project:

### 1) Onion Architecture (Clean Architecture)




 Onion Architecture is a form of layered architecture. The main difference between “the classic” three-tier architecture and the Onion, is that every outer layer sees classes from all inner layers, not only the one directly below. Moreover, the dependency direction always goes from the outside to the inside, never the other way around.

But wait, what are the layers of Onion Architecture, what do they describe, and why do they matter?

There are three main layers in Onion Architecture:

**1.** The domain layer  

**2.** The application layer

**3.** The infrastructure layer each of which has its responsibilities.

![image](https://github.com/Merve-Albayrak/UpSchool-FullStack-Development-Bootcamp/assets/63204791/444d0e03-e374-4a69-a4ba-abec178b903f)

### 2) CQRS Pattern


CQRS stands for Command and Query Responsibility Segregation, a pattern that separates read and update operations for a data store. Implementing CQRS in your application can maximize its performance, scalability, and security. The flexibility created by migrating to CQRS allows a system to better evolve over time and prevents update commands from causing merge conflicts at the domain level.


![image](https://github.com/Merve-Albayrak/UpSchool-FullStack-Development-Bootcamp/assets/63204791/0d0e59d6-6761-4b7f-a675-8b26b929b1d0)


**MediatR:** 
It is a library that makes it easy to write code with cqrs in .net environment.


 ###   3. BLAZOR APP(CONSOLE LOGGER)
 
 
 
This project listens to the signalR hub and reflects the incoming messages to the log screen.


![image](https://github.com/Merve-Albayrak/UpSchool-FullStack-Development-Bootcamp/assets/63204791/972501ba-2870-4f6c-bda8-b4d505b9c82d)
 
 






 








 
 
