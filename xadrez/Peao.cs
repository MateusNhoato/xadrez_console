﻿using tabuleiro;
namespace xadrez
{
    internal class Peao : Peca
    {
        private PartidaDeXadrez partida;
        public Peao(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(cor, tab) 
        {
            this.partida = partida;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool existeInimigo(Posicao pos)
        {
            Peca p = Tab.peca(pos);
            return p != null && p.Cor != Cor;
        }

        private bool livre(Posicao pos)
        {
            return Tab.peca(pos) == null;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] matriz = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            if( Cor == Cor.Branca)
            {
                pos.definirValores(Posicao.Linha - 1, Posicao.Coluna);
                if(Tab.posicaoValida(pos) && livre(pos))
                    matriz[pos.Linha, pos.Coluna] = true;

                pos.definirValores(Posicao.Linha - 2, Posicao.Coluna);
                if (Tab.posicaoValida(pos) && livre(pos) && QteMovimentos == 0)
                    matriz[pos.Linha, pos.Coluna] = true;

                pos.definirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tab.posicaoValida(pos) && existeInimigo(pos))
                    matriz[pos.Linha, pos.Coluna] = true;

                pos.definirValores(Posicao.Linha - 1, Posicao.Coluna +1);
                if (Tab.posicaoValida(pos) && existeInimigo(pos))
                    matriz[pos.Linha, pos.Coluna] = true;

                // #jogadaespecial en passant
                if(Posicao.Linha == 3)
                {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if(Tab.posicaoValida(esquerda) && existeInimigo(esquerda) && Tab.peca(esquerda) == partida.vulneravelEnPassant)
                        matriz[esquerda.Linha - 1, esquerda.Coluna] = true;

                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tab.posicaoValida(direita) && existeInimigo(direita) && Tab.peca(direita) == partida.vulneravelEnPassant)
                        matriz[direita.Linha - 1, direita.Coluna] = true;

                }
            }
            else
            {
                pos.definirValores(Posicao.Linha + 1, Posicao.Coluna);
                if (Tab.posicaoValida(pos) && livre(pos))
                    matriz[pos.Linha, pos.Coluna] = true;

                pos.definirValores(Posicao.Linha + 2, Posicao.Coluna);
                if (Tab.posicaoValida(pos) && livre(pos) && QteMovimentos == 0)
                    matriz[pos.Linha, pos.Coluna] = true;

                pos.definirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tab.posicaoValida(pos) && existeInimigo(pos))
                    matriz[pos.Linha, pos.Coluna] = true;

                pos.definirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tab.posicaoValida(pos) && existeInimigo(pos))
                    matriz[pos.Linha, pos.Coluna] = true;

                // #jogadaespecial en passant
                if (Posicao.Linha == 4)
                {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tab.posicaoValida(esquerda) && existeInimigo(esquerda) && Tab.peca(esquerda) == partida.vulneravelEnPassant)
                        matriz[esquerda.Linha +1,esquerda.Coluna] = true;

                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tab.posicaoValida(direita) && existeInimigo(direita) && Tab.peca(direita) == partida.vulneravelEnPassant)
                        matriz[direita.Linha +1, direita.Coluna] = true;

                }
            }

            return matriz;
        }
    }
}
