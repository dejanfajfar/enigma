import string
import itertools

BASE = string.ascii_uppercase
Type1 = 'EKMFLGDQVZNTOWYHXUSPAIBRCJ'

class Rotor:
    def __init__(self, position: str, settings: str) -> None:
        self.position = position[0].upper()
        self.initial_position = self.position
        self.settings = settings
        self.base = BASE

        for _ in itertools.repeat(None, self.__rotor_offset()):
            self.advance()

    def __rotor_offset(self) -> int:
        return BASE.index(self.position)
    
    def encode(self, input: str) -> str:
        index = BASE.index(input)
        shifted = self.base[index]
        mapped = self.settings[index]
        output = BASE[self.base.index(mapped)]
        print(f'[:{self.position}] {input} > {shifted} > {mapped} > {output}')
        return output


    def decode(self, input: int) -> int:
        index = BASE.index(input)
        shifted = self.base[index]
        mapped = self.base[self.settings.index(shifted)]
        output = BASE[self.base.index(mapped)]
        print(f'[{self.position}:] {input} > {shifted} > {mapped} > {output}')
        return output

    def advance(self) -> bool:
        self.base = self.base[1:] + self.base[:1]
        self.settings = self.settings[1:] + self.settings[:1]

        if (self.settings[0] == self.initial_position):
            return True
        return False