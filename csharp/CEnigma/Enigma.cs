namespace CEnigma
{
    public class Enigma
    {
        public Enigma(Rotor reflector, params Rotor[] rotors)
        {
            Reflector = reflector;
            Rotors = rotors;

            Console.WriteLine($"New enigma instance with rotor positions {string.Join(',', Rotors.Select(r => r.Position))}");
        }

        public Rotor Reflector { get; }

        public Rotor[] Rotors { get; }

        public string Encrypt(string input) => new(input.Trim().ToUpper().Select(i => Encrypt(i)).ToArray());

        public char Encrypt(char input)
        {
            var numberOfRotors = Rotors.Length;
            char output = input;

            for(int i = 0; i < numberOfRotors; i++)
            {
                output = Rotors[i].Encode(output);
            }

            output = Reflector.Encode(output);

            for (int i = --numberOfRotors; i >= 0; i--)
            {
                output = Rotors[i].Decode(output);
            }

            AdvanceRotors();

            return output;
        }

        public string Decrypt(string input) => new(input.Trim().ToUpper().Select(i => Decrypt(i)).ToArray());

        public char Decrypt(char input)
        {
            var numberOfRotors = Rotors.Length;
            char output = input;

            for (int i = 0; i < numberOfRotors; i++)
            {
                output = Rotors[i].Encode(output);
            }

            output = Reflector.Decode(output);

            for (int i = --numberOfRotors; i >= 0; i--)
            {
                output = Rotors[i].Decode(output);
            }

            AdvanceRotors();

            return output;
        }

        private void AdvanceRotors()
        {
            Console.Write($"{string.Join(',', Rotors.Select(r => r.Position))} -> ");
            for (int i = 0;i < Rotors.Length; i++)
            {
                if (!Rotors[i].Advance())
                {
                    break;
                }
            }
            Console.WriteLine($"{string.Join(',', Rotors.Select(r => r.Position))}");
        }
    }
}
