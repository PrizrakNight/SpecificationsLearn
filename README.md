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
# Example
In order to implement your specification, you need to inherit from the base Specification class and implement the ApplySpecificationInternal method, setting your Linq2Sql logic in it as shown below:
```csharp
public class HumanIsLife : Specification<Human>
{
    protected override Expression<Func<Human, bool>> GetSpecification()
    {
        return human => human.IsDead == false;
    }
}
```
To apply the specification you created, you need to instantiate it and use one of the Find or FindAll extension methods as shown below:
```csharp
var spec = new HumanIsLife();
var result = dbContext.Humen.FindAllBySpec(spec);
```
If you need to apply several specifications to one FindBySpec or FindAllBySpec method, then you need to use the And or Or methods, example below:
```csharp
var spec = new HumanIsLife().Or(new HumanIsDead().And(new HumanNameMatches("Adriano Giudice")));
var result = dbContext.Humen.FindAllBySpec(spec);
```

Of course, you can add extension methods for the ISpecification<TModel> interface to make it easier to combine specifications and do something like:
```csharp
var spec = Specification.Create<HumanIsLife>().Or<HumanIsDead>().And<HumanNameMatches>("Adriano Giudice");
var result = dbContext.Humen.FindAllBySpec(spec); 
```
But it would take additional time, and the whole point of the project is to learn to understand what the specification is and how it works :)

# The resulting result
We have a solution that allows specifications to be applied both on the database side, without having to load data into memory.
The solution also allows client-side specifications to be applied by working with IEnumerable<TModel>, which is extremely convenient.

Of course, this is not the best solution that came to my mind, but it fully satisfies the ideology of the Specifications pattern, all our business requirements are in one place, and we can support them without any problems.

Thank you for your attention to this project, if you have any suggestions for improvement or just constructive criticism, I would be glad to receive your feedback!
Don't get sick, be happy!
