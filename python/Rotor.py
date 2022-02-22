import string
import itertools

BASE = string.ascii_uppercase
Type1 = 'EKMFLGDQVZNTOWYHXUSPAIBRCJ'

class Rotor:
    def __init__(self, position: str, settings: str, name: str) -> None:
        self.position = position
        self.initial_position = position
        self.settings = settings
        self.base = BASE
        self.name = name

        for x in range(self.__rotor_offset()):
            self.advance()

    def __rotor_offset(self) -> int:
        return BASE.index(self.initial_position)
    
    def encode(self, input: str) -> str:
        index = BASE.index(input)
        shifted = self.base[index]
        mapped = self.settings[index]
        output = BASE[self.base.index(mapped)]
        print(f'{self.name} [:{self.position}] {input} > {shifted} > {mapped} > {output}')
        return output


    def decode(self, input: int) -> int:
        index = BASE.index(input)
        shifted = self.base[index]
        mapped = self.base[self.settings.index(shifted)]
        output = BASE[self.base.index(mapped)]
        print(f'{self.name} [{self.position}:] {input} > {shifted} > {mapped} > {output}')
        return output

    def advance(self) -> bool:
        old_position = self.position
        self.base = self.base[1:] + self.base[:1]
        self.settings = self.settings[1:] + self.settings[:1]
        self.position = self.base[0]

        print(f'{self.name} [{old_position}] -> [{self.position}]')
        if (self.settings[0] == self.initial_position):
            return True
        return False