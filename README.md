# UrbanFood

This a implementation of a local one to one
supplier to customer marketplace. 

The implementation
of the system use oracle and mongodb.

- Oracle is used as the primary database where all the primary data is store. 
Most the operations are written in PLSQL as one shot operation based PLSQL stored procedures
- MongoDB is used to store product reviews.

## Database Implementation

- UrbanFood/migrations has all the PLSQL used
- UrbanFood/migrations/schema.sql has the db schema
- UrbanFood/migrations/plsql_mutations.sql has all 
the PLSQL function which modify data
- UrbanFood/migrations/plsql_queries.sql has all the 
PLSQL queries which query the database