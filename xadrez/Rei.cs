﻿using tabuleiro;
namespace xadrez
{
    internal class Rei : Peca
    {
        public Rei(Tabuleiro tab, Cor cor ) : base(cor, tab)
        {

        }

        public override string ToString()
        {
            return "R";
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = Tab.peca(pos);
            return p == null || p.Cor != this.Cor;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] matriz = new bool[Tab.Linhas, Tab.Colunas];
            Posicao pos = new Posicao(0, 0);

            // acima
            pos.definirValores(Posicao.Linha - 1, Posicao.Coluna);

            if(Tab.posicaoValida(pos) && podeMover(pos))
                matriz[pos.Linha, pos.Coluna] = true;

            // ne
            pos.definirValores(Posicao.Linha - 1, Posicao.Coluna +1);
            if (Tab.posicaoValida(pos) && podeMover(pos))
                matriz[pos.Linha, pos.Coluna] = true;

            // direita
            pos.definirValores(Posicao.Linha, Posicao.Coluna + 1 );
            if (Tab.posicaoValida(pos) && podeMover(pos))
                matriz[pos.Linha, pos.Coluna] = true;

            // se
            pos.definirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tab.posicaoValida(pos) && podeMover(pos))
                matriz[pos.Linha, pos.Coluna] = true;

            // abaixo
            pos.definirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (Tab.posicaoValida(pos) && podeMover(pos))
                matriz[pos.Linha, pos.Coluna] = true;

            // so
            pos.definirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tab.posicaoValida(pos) && podeMover(pos))
                matriz[pos.Linha, pos.Coluna] = true;

            // esquerda
            pos.definirValores(Posicao.Linha, Posicao.Coluna - 1);
            if (Tab.posicaoValida(pos) && podeMover(pos))
                matriz[pos.Linha, pos.Coluna] = true;

            // no
            pos.definirValores(Posicao.Linha - 1, Posicao.Coluna -1);
            if (Tab.posicaoValida(pos) && podeMover(pos))
                matriz[pos.Linha, pos.Coluna] = true;

            return matriz;
        }
    }
}
