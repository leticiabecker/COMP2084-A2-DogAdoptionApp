using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// required references
using System.Web.Mvc;
using DogAdoptionApp.Controllers;
using Moq;
using DogAdoptionApp.Models;
using Assignment2.Models;
using System.Linq;

namespace Assignment2.Tests.Controllers
{
    [TestClass]
    public class PetDogsControllerTest
    {
        // globals
        PetDogsController controller;
        Mock<IPetDogsRepository> mock;
        List<PetDog> dogs;

        [TestInitialize]
        public void TestInitialize()
        {
            // arrange
            mock = new Mock<IPetDogsRepository>();

            // mock Dogs data
            dogs = new List<PetDog>
            {
                new PetDog { DogId = 1, DogName = "Dog 1", DogBreed = "Breed 1", DogAge = 1,
                    Shelter = new Shelter { ShelterId = 1, ShelterName = "Shelter 1", ShelterAddress = "1 Avenue", ShelterWebsite = "www.shelter1.ca" } },
                new PetDog { DogId = 2, DogName = "Dog 2", DogBreed = "Breed 2", DogAge = 2,
                    Shelter = new Shelter { ShelterId = 2, ShelterName = "Shelter 2", ShelterAddress = "2 Avenue", ShelterWebsite = "www.shelter2.ca" } },
                new PetDog { DogId = 3, DogName = "Dog 3", DogBreed = "Breed 3", DogAge = 3,
                    Shelter = new Shelter { ShelterId = 3, ShelterName = "Shelter 3", ShelterAddress = "3 Avenue", ShelterWebsite = "www.shelter3.ca" } }
            };

            // add Dogs data to the mock object
            mock.Setup(m => m.PetDogs).Returns(dogs.AsQueryable());

            // pass the mock to the controller
            controller = new PetDogsController(mock.Object);
        }

        // INDEX TESTS

        //Index loads the correct View
        [TestMethod]
        public void IndexLoadsIndex()
        {

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        //Index loads the correct type of data in a List
        [TestMethod]
        public void IndexShowsValidDogs()
        {
            // act
            var actual = (List<PetDog>)controller.Index().Model;

            // assert
            CollectionAssert.AreEqual(dogs, actual);
        }


        // DETAILS TESTS

        //Details loads the correct object if passed a valid Id
        [TestMethod]
        public void DetailsValidDog()
        {
            //act
            var actual = (PetDog)controller.Details(1).Model;

            // assert
            Assert.AreEqual(dogs.ToList()[0], actual);
        }

        //Details loads the error view if passed an invalid id
        [TestMethod]
        public void DetailsInvalidId()
        {
            //act
            ViewResult actual = controller.Details(4);

            // assert
            Assert.AreEqual("Error", actual.ViewName);
        }

        //Details loads the error view if passed no Id
        [TestMethod]
        public void DetailsInvalidNoId()
        {
            //act
            ViewResult actual = controller.Details(null);

            // assert
            Assert.AreEqual("Error", actual.ViewName);
        }

        //DeleteConfirmed deletes the correct object if passed a valid Id
        [TestMethod]
        public void DeleteConfirmedValidId()
        {
            //act
            ViewResult actual = controller.DeleteConfirmed(1);

            // assert
            Assert.AreEqual("Index", actual.ViewName);
        }

        //DeleteConfirmed loads the error view if passed an invalid id
        [TestMethod]
        public void DeleteConfirmedInvalidId()
        {
            //act
            ViewResult actual = controller.DeleteConfirmed(4);

            // assert
            Assert.AreEqual("Error", actual.ViewName);
        }

        //DeleteConfirmed loads the error view if passed no Id
        [TestMethod]
        public void DeleteConfirmedNoId()
        {
            //act
            ViewResult actual = controller.DeleteConfirmed(null);

            // assert
            Assert.AreEqual("Error", actual.ViewName);
        }
    }
}
