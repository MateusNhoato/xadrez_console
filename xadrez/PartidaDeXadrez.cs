﻿using System.Net.Http.Headers;
using tabuleiro;

namespace xadrez
{
    internal class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
        public bool xeque { get; private set; }


        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            pecas = new HashSet<Peca>();
            capturadas= new HashSet<Peca>();
            xeque = false;
            colocarPecas();
        }

        public Peca executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQteMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);

            tab.colocarPeca(p, destino);
            if(pecaCapturada!= null) 
            {
                capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }

        
        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if (tab.peca(pos) == null)
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            if (jogadorAtual != tab.peca(pos).Cor)
                throw new TabuleiroException("A peça escolhida não é sua!");
            if (!tab.peca(pos).existeMovimentosPossiveis())
                throw new TabuleiroException("Não há movimentos possíveis para a peça!");
        }
        
        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = tab.retirarPeca(destino);
            p.decrementarQteMovimentos();
            if(pecaCapturada != null)
            {
                tab.colocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            tab.colocarPeca(p, origem);
        }
        
        
        public void realizaJogada(Posicao origem, Posicao destino)
        {
           Peca pecaCapturada = executaMovimento(origem, destino);

            if(estaEmXeque(jogadorAtual))
            {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }


            if (estaEmXeque(adversaria(jogadorAtual)))
                xeque = true;
            else
                xeque = false;

            turno++;
            mudaJogador();
        }

        private void mudaJogador()
        {
            if (jogadorAtual == Cor.Branca)
                jogadorAtual = Cor.Preta;
            else
                jogadorAtual = Cor.Branca;
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).podeMoverPara(destino))
                throw new TabuleiroException("Posição de destino inválida.");
        }


        private Cor adversaria(Cor cor)
        {
            if (cor == Cor.Branca)
                return Cor.Preta;

            return Cor.Branca;
        }

        private Peca rei(Cor cor)
        {
            foreach(Peca p in pecasEmJogo(cor))
            {
                if (p is Rei)
                    return p;
            }
            return null;
        }

        public bool estaEmXeque(Cor cor)
        {
            Peca r = rei(cor);
            foreach(Peca p in pecasEmJogo(adversaria(cor)))
            {
                bool[,] matriz = p.movimentosPossiveis();
                if (matriz[r.Posicao.Linha, r.Posicao.Coluna])
                    return true;
            }
            return false;
        }


        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);
        }

        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca p in capturadas)
            {
                if(p.Cor == cor)
                    aux.Add(p);
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca p in pecas)
            {
                if (p.Cor == cor)
                    aux.Add(p);
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }


        private void colocarPecas()
        {

            colocarNovaPeca('c', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('d', 1, new Rei(tab, Cor.Branca));

            colocarNovaPeca('c', 8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('d', 8, new Rei(tab, Cor.Preta));

            
        }

    }
}
