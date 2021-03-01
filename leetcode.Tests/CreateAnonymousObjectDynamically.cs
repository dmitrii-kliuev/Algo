using System;
using System.Collections.Generic;
using System.Dynamic;
using Xunit;

namespace Algo.Tests
{
    public class CreateAnonymousObjectDynamically
    {
        [Fact]
        public void Test()
        {
            dynamic data = new ExpandoObject();

            IDictionary<string, object> dictionary = (IDictionary<string, object>)data;
            dictionary.Add("FirstName", "Bob");
            dictionary.Add("LastName", "Smith");

            Console.WriteLine(data.FirstName + " " + data.LastName);

            var anon = new
            {
                FirstName = "Bob",
                LastName = "Smith"
            };
        }
    }
}
