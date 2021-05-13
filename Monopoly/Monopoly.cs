using System;
using System.Collections.Generic;
using System.Linq;

using Monopoly.Models;

namespace Monopoly
{
    internal class Monopoly
    {
        private const int START_CASH = 6000;

        private readonly List<FieldInfo> _fields;
        private readonly List<PlayerInfo> _players;

        public Monopoly(ICollection<string> playerNames)
        {
            if (playerNames == null || !playerNames.Any() || playerNames.Any(x => string.IsNullOrEmpty(x)))
            {
                throw new ArgumentException();
            }

            _players = playerNames.Select(name => new PlayerInfo(name, START_CASH)).ToList();

            _fields = new List<FieldInfo>() {
                new FieldInfo("Ford",       FieldType.AUTO),
                new FieldInfo("MCDonald",   FieldType.FOOD),
                new FieldInfo("Lamoda",     FieldType.CLOTHER),
                new FieldInfo("Air Baltic", FieldType.TRAVEL),
                new FieldInfo("Nordavia",   FieldType.TRAVEL),
                new FieldInfo("Prison",     FieldType.PRISON),
                new FieldInfo("MCDonald",   FieldType.FOOD),
                new FieldInfo("TESLA",      FieldType.AUTO)
            };
        }

        internal FieldInfo GetFieldByName(string name) => _fields.FirstOrDefault(x => x.Name == name) ?? FieldInfo.EmptyField;
        
        internal PlayerInfo GetPlayerInfo(int playerIdx) => _players.ElementAtOrDefault(playerIdx - 1) ?? PlayerInfo.EmptyPlayer;

        internal IReadOnlyCollection<FieldInfo> GetFieldsList() => _fields.AsReadOnly();

        internal IReadOnlyCollection<PlayerInfo> GetPlayersList() => _players.AsReadOnly();

        internal bool Buy(int playerIdx, FieldInfo fieldInfo)
        {
            var player = GetPlayerInfo(playerIdx);

            if (!fieldInfo.IsFree
                || !fieldInfo.Type.IsPossibleToBuy()
                || player.Cash <= fieldInfo.Price)
            {
                return false;
            }

            fieldInfo.Owner = player;
            player.SubtractCash(fieldInfo.Price);

            return true;
        }

        internal bool Renta(int playerIdx, FieldInfo fieldInfo)
        {
            var player = GetPlayerInfo(playerIdx);

            if (fieldInfo.IsFree)
            {
                return false;
            }

            player.SubtractCash(fieldInfo.Rent);
            fieldInfo.Owner.AddCash(fieldInfo.Rent);

            return true;
        }
    }
}
