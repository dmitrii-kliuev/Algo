using System.Collections.Generic;
using Xunit;

namespace Algo.Tests.CrackingTheCodingInterview
{
    public class AnimalShelterTests
    {
        /* 3.6  Animal Shelter: An animal shelter, which holds only dogs and cats, operates on a strictly
                "first in, first out" basis. People must adopt either the "oldest" (based on arrival time)
                of all animals at the shelter, or they can select whether they would prefer a dog or a cat 
                (and will receive the oldest animal of that type). They cannot select which specific animal
                they would like. Create the data structures to maintain this system and implement operations
                such as enqueue, dequeueAny, dequeueDog, and dequeueCat. You may use the built-in Linked List
                data structure. */
        [Fact]
        public void Test()
        {
            var s = new AnimalShelter();

            s.Enqueue(new Cat { Name = "c5" });
            s.Enqueue(new Cat { Name = "c6" });
            s.Enqueue(new Cat { Name = "c7" });
            s.Enqueue(new Cat { Name = "c1" });
            s.Enqueue(new Dog { Name = "d1" });
            s.Enqueue(new Cat { Name = "c2" });
            s.Enqueue(new Cat { Name = "c3" });
            s.Enqueue(new Dog { Name = "d2" });
            s.Enqueue(new Dog { Name = "d3" });
            s.Enqueue(new Cat { Name = "c4" });
            s.Enqueue(new Dog { Name = "d4" });

            Assert.Equal("d1", s.DequeueDog().Name);

            Assert.Equal("c5", s.DequeueAny().Name);
            Assert.Equal("c6", s.DequeueAny().Name);
            Assert.Equal("c7", s.DequeueAny().Name);
            Assert.Equal("c1", s.DequeueAny().Name);
            Assert.Equal("c2", s.DequeueAny().Name);
            Assert.Equal("c3", s.DequeueAny().Name);
            Assert.Equal("c4", s.DequeueCat().Name);
            Assert.Equal("d2", s.DequeueDog().Name);
            Assert.Equal("d3", s.DequeueAny().Name);
            Assert.Equal("d4", s.DequeueDog().Name);
        }

        public class AnimalShelter
        {
            private Queue<Cat> _cats = new Queue<Cat>();
            private Queue<Dog> _dogs = new Queue<Dog>();
            private LinkedList<Animal> _animals = new LinkedList<Animal>();

            public void Enqueue(Animal animal)
            {
                if (animal is Dog dog)
                    _dogs.Enqueue(dog);

                if (animal is Cat cat)
                    _cats.Enqueue(cat);

                _animals.AddLast(animal);
            }

            public Animal DequeueAny()
            {
                var animal = _animals.First;
                if (animal != null && animal.Value is Dog dog)
                {
                    _dogs.Dequeue();
                }

                if (animal != null && animal.Value is Cat cat)
                {
                    _cats.Dequeue();
                }

                _animals.RemoveFirst();
                return animal?.Value;
            }

            public Dog DequeueDog()
            {
                var dog = _dogs.Dequeue();
                var d = _animals.Find(dog);
                if (d != null) _animals.Remove(d);
                return dog;
            }

            public Cat DequeueCat()
            {
                var cat = _cats.Dequeue();
                var c = _animals.Find(cat);
                if (c != null) _animals.Remove(c);
                return cat;
            }
        }

        public class Animal
        {
            public string Name { get; set; }
            public virtual string Voice { get; }
        }

        public class Cat : Animal
        {
            public override string Voice { get; } = "meow";
        }

        public class Dog : Animal
        {
            public override string Voice { get; } = "woof";
        }
    }
}
