# About
##### The purpose of this project
The main motivation and goal in creating this project was mastering the 'Specifications' pattern.

During the development of the project, it was decided to slightly modify the classic Specifications approach, whose method returned only bool, to IQueryable.

##### Why was this decision made?

Thanks to IQueryable, all specifications would not force to pull all data from the database into memory, and then filter them using a predicate, but immediately add instructions for generating SQL, which would allow the database side to apply specifications when sifting data.
