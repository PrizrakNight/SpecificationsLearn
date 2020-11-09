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
    protected override IQueryable<Human> ApplySpecificationInternal(IQueryable<Human> models)
    {
        return models.Where(h => h.IsDead == false);
    }
}
```
To apply the specification you created, you need to instantiate it and use one of the Find or FindAll extension methods as shown below:
```csharp
var spec = new HumanIsLife();
var result = dbContext.Humen.FindAll(spec);
```
If you need to apply several specifications to one Find or FindAll method, then you need to use the Combine or CombineWith methods, example below:
```csharp
var specWithCombine = new HumanIsLife().Combine(new HumanIncludeItems());
var specWithCombineWith = new HumanIsLife().CombineWith<HumanIncludeItems>();
var result = dbContext.Humen.FindAll(spec);
```
# The resulting result
We got a solution that allows us to apply specifications on the database side, and not in the memory of the client application, which allows us to optimize memory consumption for certain requests.

Of course, this is not the best solution that came to my mind, but it fully satisfies the ideology of the Specifications pattern, all our business requirements are in one place, and we can support them without any problems.

Thank you for your attention to this project, if you have any suggestions for improvement or just constructive criticism, I would be glad to receive your feedback!
Don't get sick, be happy!
