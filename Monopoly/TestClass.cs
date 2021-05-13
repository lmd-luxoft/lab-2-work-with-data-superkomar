// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;
using System.Collections.Generic;

using Monopoly.Models;

using NUnit.Framework;

namespace Monopoly
{
    [TestFixture]
    public class TestClass
    {

        [Test]
        public void NullAgumentToInit()
        {
            Assert.Throws<ArgumentException>(() => new Monopoly(null));
        }

        [Test]
        public void EmptyAgumentToInit()
        {
            Assert.Throws<ArgumentException>(() => new Monopoly(new[] {""}));
        }

        [Test]
        public void AgumentToInit()
        {
            Assert.Throws<ArgumentException>(() => new Monopoly(new string[] { "Peter", "" }));
        }

        [Test]
        public void GetPlayersListReturnCorrectList()
        {
            var players = new[] { "Peter", "Ekaterina", "Alexander" };

            var playerStartCash = 6000;
            var expectedPlayers = new List<PlayerInfo>() {
                new PlayerInfo("Peter",     playerStartCash),
                new PlayerInfo("Ekaterina", playerStartCash),
                new PlayerInfo("Alexander", playerStartCash)
            };

            var monopoly = new Monopoly(players);

            var actualPlayers = monopoly.GetPlayersList();
            Assert.AreEqual(expectedPlayers, actualPlayers);
        }

        [Test]
        public void GetFieldsListReturnCorrectList()
        {
            var expectedCompanies = new[] {
                new FieldInfo("Ford",       FieldType.AUTO),
                new FieldInfo("MCDonald",   FieldType.FOOD),
                new FieldInfo("Lamoda",     FieldType.CLOTHER),
                new FieldInfo("Air Baltic", FieldType.TRAVEL),
                new FieldInfo("Nordavia",   FieldType.TRAVEL),
                new FieldInfo("Prison",     FieldType.PRISON),
                new FieldInfo("MCDonald",   FieldType.FOOD),
                new FieldInfo("TESLA",      FieldType.AUTO)
            };

            var players = new[] { "Peter", "Ekaterina", "Alexander" };

            var monopoly = new Monopoly(players);

            var actualCompanies = monopoly.GetFieldsList();
            Assert.AreEqual(expectedCompanies, actualCompanies);
        }

        [Test]
        public void PlayerBuyNoOwnedCompanies()
        {
            var players = new[] { "Peter", "Ekaterina", "Alexander" };

            var monopoly = new Monopoly(players);

            var actualPlayerIdx = 1;

            var field = monopoly.GetFieldByName("Ford");
            monopoly.Buy(actualPlayerIdx, field);
            
            var expectedPlayer = new PlayerInfo("Peter", 5500);
            var actualPlayer = monopoly.GetPlayerInfo(actualPlayerIdx);
            Assert.AreEqual(expectedPlayer, actualPlayer);

            var actualField = monopoly.GetFieldByName("Ford");
            Assert.AreEqual(actualPlayer, actualField.Owner);
        }

        [Test]
        public void RentaShouldBeCorrectTransferMoney()
        {
            var players = new[] { "Peter", "Ekaterina", "Alexander" };
            var monopoly = new Monopoly(players);

            var actualField = monopoly.GetFieldByName("Ford");

            monopoly.Buy(1, actualField);

            actualField = monopoly.GetFieldByName("Ford");
            monopoly.Renta(2, actualField);

            var player1 = monopoly.GetPlayerInfo(1);
            Assert.AreEqual(5750, player1.Cash);

            var player2 = monopoly.GetPlayerInfo(2);
            Assert.AreEqual(5750, player2.Cash);
        }
    }
}
