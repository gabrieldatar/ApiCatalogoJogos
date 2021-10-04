﻿using ApiCatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>()
        {
            {Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"),new Jogo{Id=Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"),Nome="A de volta",Produtora="O A",Preco=200 } },
            {Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"),new Jogo{Id=Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"),Nome="A se foi",Produtora="O A",Preco=270} },
            {Guid.Parse("5e99c84a-108b-4dfa-ab7e-d8c55957a7ec"),new Jogo{Id=Guid.Parse("5e99c84a-108b-4dfa-ab7e-d8c55957a7ec"),Nome="Z na area",Produtora="O Z",Preco=120} },
            {Guid.Parse("da033439-f352-4539-879f-515759312d53"),new Jogo{Id=Guid.Parse("da033439-f352-4539-879f-515759312d53"),Nome="Z a festa",Produtora="O Z",Preco=210} },
            {Guid.Parse("92576bd2-388e-4f5d-96c1-8bfda6c5a268"),new Jogo{Id=Guid.Parse("92576bd2-388e-4f5d-96c1-8bfda6c5a268"),Nome="De tiro atirando",Produtora="Helenão",Preco=70} },
            {Guid.Parse("c3c9b5da-6a45-4de1-b28b-491cbf83b589"),new Jogo{Id=Guid.Parse("c3c9b5da-6a45-4de1-b28b-491cbf83b589"),Nome="De voo na paz",Produtora="A 13",Preco=80} },
            {Guid.Parse("33d7837d-504d-48db-8e67-508d7e139205"),new Jogo{Id=Guid.Parse("33d7837d-504d-48db-8e67-508d7e139205"),Nome="Jogo Ruim",Produtora="Produtora boa",Preco=373} }
            
        };

        public Task Atualizar(Jogo jogo)
        {
            jogos[jogo.Id] = jogo;

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            // Fechar a conexão com o banco
        }

        public Task Inserir(Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo);

            return Task.CompletedTask;
        }

        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> Obter(Guid id)
        {
            if (!jogos.ContainsKey(id))
            {
                return null;
            }

            return Task.FromResult(jogos[id]);
        }

        public Task<List<Jogo>> Obter(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());
        }

        public Task<List<Jogo>> ObterSemLambda(string nome, string produtora)
        {
            var retorno = new List<Jogo>();
            foreach(var jogo in jogos.Values)
            {
                if(jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora))
                {
                    retorno.Add(jogo);
                }
            }

            return Task.FromResult(retorno);
        }

        public Task Remover(Guid id)
        {
            jogos.Remove(id);

            return Task.CompletedTask;
        }
    }
}
