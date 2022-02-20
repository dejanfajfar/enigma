using CEnigma;

var rotor1 = new Rotor(Rotor.Type1, 'C');
var rotor2 = new Rotor(Rotor.Type1, 'A');
var rotor3 = new Rotor(Rotor.Type1, 'D');
var reflector = new Rotor(Rotor.REFLECTOR);

var deRotor1 = new Rotor(Rotor.Type1, 'C');
var deRotor2 = new Rotor(Rotor.Type1, 'A');
var deRotor3 = new Rotor(Rotor.Type1, 'D');


var enigma = new Enigma(reflector, rotor1, rotor2, rotor3);
var enigma2 = new Enigma(reflector, deRotor1, deRotor2, deRotor3);

var encrypted = enigma.Encrypt("hello");

Console.WriteLine(encrypted);

var decrypted = enigma2.Decrypt(encrypted);

Console.WriteLine(decrypted);


Console.ReadKey();