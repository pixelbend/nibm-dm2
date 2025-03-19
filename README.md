# UrbanFood

This a implementation of a local one to one
supplier to customer marketplace. 

The implementation
of the system use oracle and mongodb.

- Oracle is used as the primary database where all the primary data is store. 
Most the operations are written in PLSQL as one shot operation based PLSQL stored procedures
- MongoDB is used to store product reviews.

## Database Implementation

```
UrbanFood/
|-- migrations/
|   |-- schema.sql             # Database schema
|   |-- seed.sql               # Database sample data set
|   |-- plsql_mutations.sql    # PLSQL functions for modifying data
|   |-- plsql_queries.sql      # PLSQL queries for retrieving data
```

## Setting Up and Running the Project with Docker

### Prerequisites
Ensure you have the following installed on your system:

- **[Docker](https://www.docker.com/get-started)**
- **[Docker Compose](https://docs.docker.com/compose/install/)** (Comes pre-installed with Docker Desktop)

### Installation and Running the Project

1. **Install Docker (if not installed)**  
   - **Windows & Mac:** Download and install [Docker Desktop](https://www.docker.com/products/docker-desktop).  
   - **Linux:** Install via package manager:
     ```sh
     sudo apt-get update
     sudo apt-get install docker-ce docker-ce-cli containerd.io
     ```
     Ensure your user is added to the Docker group:
     ```sh
     sudo usermod -aG docker $USER
     ```

2. **Clone the Repository**  
   ```sh
   git clone https://github.com/pixelbend/nibm-dm2.git
   cd nibm-dm2
   docker compose up -d -- this creates a mongodb and oracledb instance
   docker compose down -- this is used to shut down mongodb and oracledb instance
   ```
