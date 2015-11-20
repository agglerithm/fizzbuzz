using System;
using System.Collections.Generic;
using System.Linq;
using FizzBuzzLib;
using NUnit.Framework;

namespace FizzBuzzTests
{
    [TestFixture]
    public class FizzBuzzerTester
    {
        private IFizzBuzzer _sut;
        [SetUp]
        public void setup()
        {
            _sut = new FizzBuzzer();
        }

        [Test] 
        public void will_throw_exception_if_upper_bound_too_low()
        {
            try
            {
                var lst = _sut.GetFizzBuzzList(-3);
            }
            catch (ArgumentOutOfRangeException)
            {
                
            }
        }

        [Test]
        public void will_return_correct_default_list()
        {
            //Arrange
            //Act
            var lst = _sut.GetFizzBuzzList(20);
            //Assert
            var fizzCount = lst.Count(l => l == "Fizz");
            var buzzCount = lst.Count(l => l == "Buzz");
            var fizzBuzzCount = lst.Count(l => l == "FizzBuzz");
            Assert.That(fizzCount.ToString() == "5");
            Assert.That(buzzCount.ToString() == "3");
            Assert.That(fizzBuzzCount.ToString() == "1");
        }

        [Test]
        public void will_return_correct_custom_list()
        {
            //Arrange
            var dic = new Dictionary<int, string>();
            dic[4] = "Foo";
            dic[7] = "Bar";
            //Act
            var lst = _sut.GetCustomFizzBuzzList(28, dic);
            //Assert
            var fooCount = lst.Count(l => l == "Foo");
            var barCount = lst.Count(l => l == "Bar");
            var fooBarCount = lst.Count(l => l == "FooBar");
            Assert.That(fooCount.ToString() == "6");
            Assert.That(barCount.ToString() == "3");
            Assert.That(fooBarCount.ToString() == "1");


        }

        [Test]
        public void will_return_correct_large_custom_list()
        {
            //Arrange
            var dic = new Dictionary<int, string>();
            dic[2] = "Chicken";
            dic[3] = "Of";
            dic[5] = "The";
            dic[7] = "Sea";
            //Act
            var lst = _sut.GetCustomFizzBuzzList(1000, dic);
            //Assert
            var chickenCount = lst.Count(l => l == "Chicken");
            var ofCount = lst.Count(l => l == "Of");
            var theCount = lst.Count(l => l == "The");
            var seaCount = lst.Count(l => l == "Sea");
            var chickenOfCount = lst.Count(l => l == "ChickenOf");
            var ofTheCount = lst.Count(l => l == "OfThe");
            var theSeaCount = lst.Count(l => l == "TheSea");
            var ofSeaCount = lst.Count(l => l == "OfSea");
            var chickenTheCount = lst.Count(l => l == "ChickenThe");
            var chickenSeaCount = lst.Count(l => l == "ChickenSea");
            var ofTheSeaCount = lst.Count(l => l == "OfTheSea");
            var chickenOfTheCount = lst.Count(l => l == "ChickenOfThe");
            var chickenOfTheSeaCount = lst.Count(l => l == "ChickenOfTheSea");
            Assert.That(chickenCount.ToString() == "229");
            Assert.That(seaCount.ToString() == "38");
            Assert.That(ofCount.ToString() == "115");
            Assert.That(chickenOfCount.ToString() == "114");
            Assert.That(theCount.ToString() == "58");
            Assert.That(ofTheCount.ToString() == "28");
            Assert.That(theSeaCount.ToString() == "9");
            Assert.That(ofSeaCount.ToString() == "19");
            Assert.That(chickenTheCount.ToString() == "57");
            Assert.That(chickenSeaCount.ToString() == "38");
            Assert.That(ofTheSeaCount.ToString() == "5");
            Assert.That(chickenOfTheCount.ToString() == "29");
            Assert.That(chickenOfTheSeaCount.ToString() == "4");

        }

        [Test]
        public void will_return_numeric_list_if_empty_dictionary()
        { 
            //Arrange
            var dic = new Dictionary<int, string>(); 
            //Act
            var lst = _sut.GetCustomFizzBuzzList(28, dic);
            //Assert
            for (int i = 0; i < 28; i++)
            {
                Assert.That(lst[i] == (i+1).ToString());
            }
        }
    }
}
