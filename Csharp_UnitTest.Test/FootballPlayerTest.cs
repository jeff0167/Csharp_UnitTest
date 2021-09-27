using Microsoft.VisualStudio.TestTools.UnitTesting;
using Csharp_UnitTest;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Csharp_UnitTest.Test
{
    [TestClass]
    public class FootballPlayerTest
    {
        FootballPlayer footballPlayer;

        [TestInitialize]
        public void InitializeClass() // resets us with a fresh new player object before each testmethord
        {
            footballPlayer = new FootballPlayer("Mezi ronaldo",1747,50); // GETS ID 0 !!!
        }

        [TestMethod]
        public void FootballPlayer_IdShouldIncresebyOneForEachNewObject()
        {
            //arrange
            List<FootballPlayer> footballTeam = new List<FootballPlayer>();

            for (int i = 0; i < 98; i++)
            {
                //act
                footballTeam.Add(new FootballPlayer("Mezi ronaldo", double.Parse(new Random().Next().ToString()), i+1)); // we say i+1 cause the for loop starts with i=0 and shirt number must be 1 or higher
                //assert
                Assert.AreEqual(footballTeam[i].Id, i + 1);  // we start with i=1 so we get id 1 cause an object with id of 0 already has been instantiated
            }
        }

        [TestMethod]
        public void FootballPlayer_ShouldSetCorrectValues() // simple constructor call
        {
            Assert.AreEqual(footballPlayer.Name, "Mezi ronaldo"); // default values
            Assert.AreEqual(footballPlayer.Price, 1747);
            Assert.AreEqual(footballPlayer.ShirtNumber, 50);


            string name = "Ronaldinio";
            double price = 957747.57;
            int shirtNumber = 57;

            footballPlayer = new FootballPlayer(name, price, shirtNumber);

            Assert.AreEqual(footballPlayer.Name, name); 
            Assert.AreEqual(footballPlayer.Price, price);
            Assert.AreEqual(footballPlayer.ShirtNumber, shirtNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void FootballPlayer_NameShouldThrowNullErrorIfSetToNull()
        {
            footballPlayer.Name = null;
        }  
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FootballPlayer_NameShouldThrowErrorOnInvalidInput()
        {
            footballPlayer.Name = "ike"; // to short
        }    
        
        [TestMethod]
        public void FootballPlayer_ValidNameValues()
        {
            try
            {
                footballPlayer.Name = "sven"; 
                footballPlayer.Name = "Mezi bugati"; 
                footballPlayer.Name = "football"; 
                footballPlayer.Name = "donald duck";          
                
                //footballPlayer.Name = "do";  //this makes it fail even after all the other names, cause the name is set one at a time        
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        [DataRow(101)]
        [DataRow(0)]
        [DataRow(int.MaxValue)]
        [DataRow(int.MinValue)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FootballPlayer_InvalidShirtValues(int value)  // 1-100 is valid
        {
            footballPlayer.ShirtNumber = value;           
        }

        [TestMethod]
        [DataRow(-354)]
        [DataRow(0)]
        [DataRow(int.MinValue)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FootballPlayer_InvalidPriceValues(double value)  // 0 < value,  is valid
        {
            footballPlayer.Price = value;
        }

        [TestMethod]
        public void FootballPlayer_ShouldOutPutToStringMethod()  // 0 < value,  is valid
        {
            FootballPlayer Player = new FootballPlayer("Mezi ronaldo", 1747, 50);
            int id = 123;
            Player.Id = id;
            Assert.AreEqual(Player.ToString(), $"id: {id}, name: Mezi ronaldo, price: 1747, shirt number: 50");
        }
    }
}
