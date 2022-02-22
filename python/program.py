import Rotor
import Reflector
from Enigma import Enigma

rotor1 = Rotor.Rotor("C", Rotor.Type1, 'r1')
rotor2 = Rotor.Rotor("A", Rotor.Type1, 'r2')
rotor3 = Rotor.Rotor("D", Rotor.Type1, 'r3')

rotor12 = Rotor.Rotor("C", Rotor.Type1, 'r1')
rotor22 = Rotor.Rotor("A", Rotor.Type1, 'r2')
rotor32 = Rotor.Rotor("D", Rotor.Type1, 'r3')

reflector = Reflector.Reflector(Reflector.default_configuration)


enigma1 = Enigma([rotor1, rotor2, rotor3], reflector)
enigma2 = Enigma([rotor12, rotor22, rotor32], reflector)

original_message = 'THEQUICKBROWNFOXJUMPSOVERTHELAZYDOG'

encoded_message = enigma1.encode(original_message)

decoded_message = enigma2.decode(encoded_message)

print('----')
print(f'original : {original_message}')
print(f'encoded  : {encoded_message}')
print(f'decoded  : {decoded_message}')