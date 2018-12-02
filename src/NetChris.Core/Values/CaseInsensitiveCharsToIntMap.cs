using System.Collections.Generic;

namespace NetChris.Core.Values
{
    public class CaseInsensitiveCharsToIntMap
    {
        private readonly IDictionary<char, ulong> _charToIntMap;
        private readonly IDictionary<ulong, char> _intToCharMap;

        public CaseInsensitiveCharsToIntMap()
        {
            _charToIntMap = new Dictionary<char, ulong>();
            _intToCharMap = new Dictionary<ulong, char>();
        }

        public ulong GetInt(char value)
        {
            return _charToIntMap[value];
        }

        public char GetChar(ulong value)
        {
            return _intToCharMap[value];
        }

        public void Register(ulong numericValue, char characterValue, params char[] alternateCharacters)
        {
            var allCharacters = new HashSet<char>
            {
                char.ToUpperInvariant(characterValue),
                char.ToLowerInvariant(characterValue)
            };

            foreach (var alternateCharacter in alternateCharacters)
            {
                allCharacters.Add(char.ToUpperInvariant(alternateCharacter));
                allCharacters.Add(char.ToLowerInvariant(alternateCharacter));
            }

            _intToCharMap[numericValue] = characterValue;

            foreach (var caseOfCharacter in allCharacters)
            {
                _charToIntMap[caseOfCharacter] = numericValue;
            }
        }

        public bool IsMapped(char character)
        {
            return _charToIntMap.ContainsKey(character);
        }
    }
}
