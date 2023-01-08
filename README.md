# xadrez_console ♟
Aplicação feita seguindo o curso "C# COMPLETO Programação Orientada a Objetos + Projetos", do professor Nelio Alves.

## Tecnologias
[![Tipo de aplicação](https://img.shields.io/badge/aplica%C3%A7%C3%A3o-console-blue.svg)](#)

[![Paradigma](https://img.shields.io/badge/paradigma-POO-blue.svg)](#)

[![Linguagem](https://img.shields.io/badge/linguagem-C%23-brightgreen.svg)](https://docs.microsoft.com/pt-br/dotnet/csharp/)

## Descrição
Se trata de um jogo de xadrez feito em console, com toda a lógica original do jogo, além das jogadas especiais (promoção, en passant e roque).

## Demonstração
![Demo](https://media.giphy.com/media/trd1wswZfCaENUq27x/giphy.gif)

## Instalação
Para instalar o projeto, basta clonar o repositório:
```
git clone https://github.com/MateusNhoato/xadrez_console.git
```

## Tutorial
Assim como no xadrez tradicional, as peças brancas começam e o turnos se alteram. Todas as peças são representadas por letras. Por escolha do estilo do layout, as peças pretas são representadas por letras douradas.
### Peças
- P : peão
- T : torre
- C : cavalo
- B : bispo
- D : rainha (dama)
- R : rei

### Fazendo uma jogada
Para se fazer uma jogada, primeiro você escolhe a linha e a coluna onde a peça que quer mexer se encontra. As linhas vão de 1 até 8, e as colunas de a até h.
![EsquemaBoard](https://www.regencychess.co.uk/blog/wp-content/uploads/2012/05/starting-positon-algebraic.jpg)

Após a seleção da peça, todas as jogadas disponíveis para dita peça ficam destacadas e então basta só escolher.
### Jogadas Especiais 
**Promoção**
- Quando um peão chega na segunda linha inimiga (linha 8 para as brancas e linha 1 para as pretas), ele automaticamente vira uma rainha.

**En passant**
- Permite ao peão capturar um outro peão inimigo que acabou de passar por ele.

**Roque**
- Jogada especial que envolve a movimentação de duas peças em um único lance, o rei e uma das torres. O objetivo da jogada é proteger o rei, tirando-o do centro. O movimento consiste no deslocamento lateral do rei na primeira fileira em duas casas na direção da torre com a qual desejar "rocar", e a torre escolhida passa através do rei permanecendo na primeira casa após o "salto".
Antes de executar a jogada, é necessário o atendimento aos seguintes requisitos:
    - O rei e a torre envolvida não podem ter se movimentado nenhuma vez desde o início do jogo;
    - As casas entre o rei e a torre devem estar desocupadas;
O rei não pode estar em xeque, e também não pode ficar em xeque depois do roque.
    - Nenhuma das casas onde o rei passar ou ficar deverá estar no raio de ação de uma peça adversária. Isto não se aplica à torre envolvida.



