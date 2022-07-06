# C#_Xadrez


Projeto de tabuleiro de xadrez com C# com tudo que foi utilizado nos repositorios de C# até o momento


Está sendo considerado a ordem da matriz vindo primeiro a coluna, e depois a linha, pois esta sendo considerado o tabuleiro a seguir:

```
8 - - - - - - - -
7 - - - - - - - -
6 - - - - - - - -
5 - - - - - - - -
4 - - - - - - - -
3 - - - - - - - -
2 - - - - - - - -
1 - - - - - - - -
  a b c d e f g h
```
  
  Então se for escolhido o local de Origem c3 e o de destino d5 onde ira capturar uma peça, então temos:
  
```
8 - - - - - - - -                             8 - - - - - - - -
7 - - - - - - - -                             7 - - - - - - - -
6 - - - - - - - -                             6 - - - - - - - -
5 - - - O - - - -              →              5 - - - X - - - -
4 - - - - - - - -                             4 - - - - - - - -
3 - - X - - - - -                             3 - - - - - - - -
2 - - - - - - - -                             2 - - - - - - - - 
1 - - - - - - - -                             1 - - - - - - - -  
  a b c d e f g h                               a b c d e f g h
```
  .
