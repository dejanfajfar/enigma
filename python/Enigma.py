from typing import List
from Rotor import Rotor
from Reflector import Reflector

class Enigma:
    def __init__(self, rotors: List[Rotor], reflector: Reflector) -> None:
        self.rotors = rotors
        self.reflector = reflector

    def encode(self, text: str) -> str:
        output = ''
        for letter in text.upper():
            output += self.encode_letter(letter)
        return output
    
    def decode(self, text: str) -> str:
        output = ''
        for letter in text.upper():
            output += self.decode_letter(letter)
        return output
    
    def encode_letter(self, letter: str) -> str:
        for rotor in self.rotors:
            letter = rotor.encode(letter)
        
        letter = self.reflector.encode(letter)

        for rotor in reversed(self.rotors):
            letter = rotor.decode(letter)

        self.__advance();

        return letter
    
    def decode_letter(self, letter: str) -> str:
        for rotor in self.rotors:
            letter = rotor.encode(letter)
        
        letter = self.reflector.decode(letter)

        for rotor in reversed(self.rotors):
            letter = rotor.decode(letter)

        self.__advance();

        return letter

    def __advance(self) -> None:
        for rotor in self.rotors:
            if not rotor.advance():
                break