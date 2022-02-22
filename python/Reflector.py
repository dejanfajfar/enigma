import string

default_configuration = 'FKQHTLXOCBJSPDZRAMEWNIUYGV'

class Reflector:
    def __init__(self, configuration: str) -> None:
        self.configuration = configuration
        self.base = string.ascii_uppercase

    def encode(self, text) -> str:
        index = self.base.index(text[0].upper())
        output = self.configuration[index]
        print(f'[::] {text} > {output}')
        return output

    def decode(self, text) -> str:
        index = self.configuration.index(text[0].upper())
        return self.base[index]
