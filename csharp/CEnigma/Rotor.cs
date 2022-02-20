namespace CEnigma
{
    public class Rotor
    {
        public const string REFLECTOR = "FKQHTLXOCBJSPDZRAMEWNIUYGV";
        public const string Type1 = "EKMFLGDQVZNTOWYHXUSPAIBRCJ";
        public const string Type2 = "AJDKSIRUXBLHWTMCQGZNPYFVOE";
        public const string Type3 = "BDFHJLCPRTXVZNYEIWGAKMUSQO";
        public const string Base = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public Rotor(string rotorSettings, char? initialPosition = null)
        {
            Position = initialPosition.HasValue ? initialPosition.Value : 'A';
            _initialRotorPosition = Position;
            _inputMappings = new Dictionary<char, char>();
            _rotorMappings = new Dictionary<char, char>();
            _outputMappings = new Dictionary<char, char>();

            _rotorSetting = rotorSettings;
            _isReflector = !initialPosition.HasValue;
            CalculateMappings();
        }

        public char Position { get; private set; }

        private char _initialRotorPosition;

        public char Encode(char input)
        {
            if (_isReflector)
            {
                Console.WriteLine($"[>>] {input} > {_rotorMappings[input]}");
                return _rotorMappings[input];
            }

            var offsetInput = _inputMappings[input];

            var mappingOutput = _rotorMappings[offsetInput];

            var offsetMappingOutput = _outputMappings[mappingOutput];

            Console.WriteLine($"[{Position}<] {input} > {offsetInput} > {mappingOutput} > {offsetMappingOutput}");

            return offsetMappingOutput;
        }

        public char Decode(char input)
        {
            if (_isReflector)
            {
                var reflectorOutput = _rotorMappings.FirstOrDefault(m => m.Value == input).Key;
                Console.WriteLine($"[>>] {input} > {reflectorOutput}");
                return reflectorOutput;
            }

            var offsetInput = _outputMappings.FirstOrDefault(m => m.Value == input).Key;

            var mappingOutput = _rotorMappings.FirstOrDefault(m => m.Value == offsetInput).Key;

            var offsetMappingOutput = _inputMappings.FirstOrDefault(m => m.Value == mappingOutput).Key;

            Console.WriteLine($"[>{Position}] {input} > {offsetInput} > {mappingOutput} > {offsetMappingOutput}");

            return offsetMappingOutput;
        }

        private int RotorOffset => Position - 65;

        private readonly string _rotorSetting;
        private readonly bool _isReflector;
        private IDictionary<char, char> _inputMappings;
        private IDictionary<char, char> _rotorMappings;
        private IDictionary<char, char> _outputMappings;

        private void CalculateMappings()
        {
            _inputMappings.Clear();
            _rotorMappings.Clear();
            _outputMappings.Clear();
            foreach(var input in Base.ToList())
            {
                _inputMappings.Add(input, (char)(((input - 65 + RotorOffset) % 26) + 65));

                _rotorMappings.Add(input, _rotorSetting[Base.IndexOf(input)]);

                _outputMappings.Add(input, Foo(input));
            }
        }

        private char Foo(char input)
        {
            var mapping = input - RotorOffset;

            if (mapping >= 65)
            {
                return (char)mapping;
            }
            else
            {
                return (char)(mapping + 26);
            }
        }

        public bool Advance()
        {
            var currentIndex = _rotorSetting.IndexOf(Position);
            Position = _rotorSetting[(++currentIndex) % 26];
            CalculateMappings();
            return Position == _initialRotorPosition;
        }
    }
}
