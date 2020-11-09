# About
#### The purpose of this project
The main motivation and goal in creating this project was mastering the 'Specifications' pattern.

During the development of the project, it was decided to slightly modify the classic Specifications approach, whose method returned only bool, to IQueryable.

#### Why was this decision made?

Thanks to IQueryable, all specifications would not force to pull all data from the database into memory, and then filter them using a predicate, but immediately add instructions for generating SQL, which would allow the database side to apply specifications when sifting data.
#### What i wanted to do
In the future, I wanted to separate the Specification pattern for working and filtering data both on the database side and on the client side in memory, but so far, unfortunately, I have implemented only one solution that allows you to work on the database side.

#### Summary
As a result, you can see a non-standard solution using the Specifications pattern.
This solution certainly has its drawbacks, but the main task was solved.
