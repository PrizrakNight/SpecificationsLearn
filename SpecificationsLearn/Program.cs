using SpecificationsLearn.Generators;
using SpecificationsLearn.Models;
using SpecificationsLearn.RandomPersonProvider;
using SpecificationsLearn.Repositories;
using SpecificationsLearn.Specifications;
using SpecificationsLearn.Specifications.Implementation;
using System;

namespace SpecificationsLearn
{
    internal class Program
    {
        private const int _countHumans = 10;

        private static IApplicationUnitOfWork _applicationUnitOfWork;
        private static IRandomPersonProvider _randomPersonProvider;

        //Доделать пользовательский ввод:
        //                      1. Пользователь должен иметь возможность добавлять, обновлять, удалять и получать список сущностей
        //                      2. Пользователь должен иметь возможность применять фильтры
        //
        //Доделать использование БД из настроек файла.
        private static void Main(string[] args)
        {
            _applicationUnitOfWork = new ApplicationUnitOfWork();
            _randomPersonProvider = new RandomUserProvider();

            SeedData();
            BeginUserInput();
        }

        private static void BeginUserInput()
        {
            var enabled = true;
            var allHumans = _applicationUnitOfWork.Humans.AsQueryable().FindAll(null);

            while (enabled)
            {
                var cmd = Console.ReadLine().ToLower();

                switch (cmd)
                {
                    case "e": enabled = false; break;
                    case "l":
                        var specification = Specification<Human>.Create<HumanIncludeItems>().CombineWith<HumanIsDead>();
                        var result = _applicationUnitOfWork.Humans.AsQueryable().FindAll(specification);

                        foreach (var humanL in result) Print(humanL);
                        break;
                }
            }
        }

        private static void Print(Human human) => Console.WriteLine($"{human.Name}, IsDead: " + human.IsDead);

        private static void SeedData()
        {
            var humans = new Human[_countHumans];
            var humanGenerator = new HumanGenerator();
            var persons = _randomPersonProvider.GetPersonsAsync(_countHumans).Result;

            for (int i = 0; i < _countHumans; i++)
            {
                humans[i] = humanGenerator.Generate();
                humans[i].Name = persons[i].Name.ToString();
            }

            _applicationUnitOfWork.Humans.Insert(humans);
        }
    }
}
