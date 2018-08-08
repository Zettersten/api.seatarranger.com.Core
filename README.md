![logo](https://media.glassdoor.com/sqll/1001687/bytecubed-squarelogo-1437055577282.png "Logo")

# Seat Arranger
ByteCubed algorithm &amp; approach demonstration

## Design overview
This repository attempts to tackle the *wedding planner* challenge, where given a collection of tables and parties, the application is required to seat all parties at the available tables while also adhere to the party’s "dislike" preferences.

### Approach
The table and party collection were unsorted and due to the nature of the application (not being a scalability challenge) it felt pertinent to allow sorting both collections from largest to smallest.

### Data structure
For this challenge I used ArrayLists and HashSets. The ArrayLists were the structures that held both the table and party collection. The HashSet was used to track "sat" parties which allotted a reduction the overall number of interactions.

### Development process
This project practiced TDD where I was able to write failing tests against interfaces and then later implementing solutions to pass said-test. I structured this project to take advantage of DI-best practices. All code is implemented against interfaces to allow for future interoperability with opportunity to change the main seating algorithm and persistence strategy.

### Run the application
#### Web demo
This demo was written in Angular6 and interacts with a RESTFul Web API. 
- API Specification (http://wsazureeast070.azurewebsites.net/api/swagger/index.html)
- Demo (http://wsazureeast070.azurewebsites.net/)
#### CLI Demo
This demo was written in .NET Core Standard library and is available to run in a container.
- See docker-compose.yml (src/seatarranger.com.Console/DockerFile)