using Administrativo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Administrativo.Data
{
    public class DbInitializer
    {
        public static void Initialize(AlexContext context)
        {
            context.Database.EnsureCreated();

            if (context.Administradores.Any()) return;

            var administrador = new Administrador() { Nome = "Joao da Silva", Login = "joao.silva", Senha = "123" };   
            context.Administradores.Add(administrador);
            context.SaveChanges();
            /*
            // Adicionando os Temas
            var tema = new Tema() { IncPor = administrador, DataInc = DateTime.Now, ModPor = administrador, DataMod = DateTime.Now, Nome = "Infecção", Descricao = "Infecções Sexualmente Transmissíveis" };
            var temas = new Tema[]
            {
                tema,
                new Tema() { IncPor = administrador, DataInc = new DateTime(2018,1,1), ModPor = administrador, DataMod = new DateTime(2018,1,1), Nome = "Tratamento", Descricao = "Infecções Sexualmente Transmissíveis" },
                new Tema() { IncPor = administrador, DataInc = new DateTime(2018,1,1), ModPor = administrador, DataMod = new DateTime(2018,1,1), Nome = "Contracepção", Descricao = "Infecções Sexualmente Transmissíveis" }
            };
            context.Temas.AddRange(temas);
            context.SaveChanges();

            // Adicionando as Perguntas
            var pergunta = new Pergunta() { IncPor = administrador, DataInc = DateTime.Now, ModPor = administrador, DataMod = DateTime.Now, Descricao = "Pergunta 1", Tema = tema };
            var perguntas = new Pergunta[]
            {
                pergunta,
                new Pergunta() { IncPor = administrador, DataInc = new DateTime(2018,1,1), ModPor = administrador, DataMod = new DateTime(2018,1,1), Descricao = "Pergunta 2", Tema = tema },
            };
            context.Perguntas.AddRange(perguntas);
            context.SaveChanges();

            // Respostas
            var respostas = new Resposta[]
            {
                new Resposta() { IncPor = administrador, DataInc = DateTime.Now, ModPor = administrador, DataMod = DateTime.Now, Descricao = "Resposta 1", Pergunta = pergunta }
            };
            context.Respostas.AddRange(respostas);
            context.SaveChanges();
            */
            //Estados
            var estados = new Estado[]
            {
                new Estado() { IncPor = administrador, DataInc = DateTime.Now, ModPor = administrador, DataMod = DateTime.Now, Nome = "Acre", UF = "AC" },
                new Estado() { IncPor = administrador, DataInc = DateTime.Now, ModPor = administrador, DataMod = DateTime.Now, Nome = "Alagoas", UF = "AL" },
                new Estado() { IncPor = administrador, DataInc = DateTime.Now, ModPor = administrador, DataMod = DateTime.Now, Nome = "Amapá", UF = "AP" },
                new Estado() { IncPor = administrador, DataInc = DateTime.Now, ModPor = administrador, DataMod = DateTime.Now, Nome = "Amazonas", UF = "AM" },
                new Estado() { IncPor = administrador, DataInc = DateTime.Now, ModPor = administrador, DataMod = DateTime.Now, Nome = "Bahia", UF = "BA" },
                new Estado() { IncPor = administrador, DataInc = DateTime.Now, ModPor = administrador, DataMod = DateTime.Now, Nome = "Ceará", UF = "CE" },
                new Estado() { IncPor = administrador, DataInc = DateTime.Now, ModPor = administrador, DataMod = DateTime.Now, Nome = "Distrito Federal", UF = "DF" },
                new Estado() { IncPor = administrador, DataInc = DateTime.Now, ModPor = administrador, DataMod = DateTime.Now, Nome = "Espírito Santo", UF = "ES" },
                new Estado() { IncPor = administrador, DataInc = DateTime.Now, ModPor = administrador, DataMod = DateTime.Now, Nome = "Goiás", UF = "GO" },
                new Estado() { IncPor = administrador, DataInc = DateTime.Now, ModPor = administrador, DataMod = DateTime.Now, Nome = "Maranhão", UF = "MA" },
                new Estado() { IncPor = administrador, DataInc = DateTime.Now, ModPor = administrador, DataMod = DateTime.Now, Nome = "Mato Grosso", UF = "MT" },
                new Estado() { IncPor = administrador, DataInc = DateTime.Now, ModPor = administrador, DataMod = DateTime.Now, Nome = "Mato Grosso do Sul", UF = "MS" },
                new Estado() { IncPor = administrador, DataInc = DateTime.Now, ModPor = administrador, DataMod = DateTime.Now, Nome = "Minas Gerais", UF = "MG" },
                new Estado() { IncPor = administrador, DataInc = DateTime.Now, ModPor = administrador, DataMod = DateTime.Now, Nome = "Pará", UF = "PA" },
                new Estado() { IncPor = administrador, DataInc = DateTime.Now, ModPor = administrador, DataMod = DateTime.Now, Nome = "Paraíba", UF = "PB" },
                new Estado() { IncPor = administrador, DataInc = DateTime.Now, ModPor = administrador, DataMod = DateTime.Now, Nome = "Paraná", UF = "PR" },
                new Estado() { IncPor = administrador, DataInc = DateTime.Now, ModPor = administrador, DataMod = DateTime.Now, Nome = "Pernambuco", UF = "PE" },
                new Estado() { IncPor = administrador, DataInc = DateTime.Now, ModPor = administrador, DataMod = DateTime.Now, Nome = "Piauí", UF = "PI" },
                new Estado() { IncPor = administrador, DataInc = DateTime.Now, ModPor = administrador, DataMod = DateTime.Now, Nome = "Rio de Janeiro", UF = "RJ" },
                new Estado() { IncPor = administrador, DataInc = DateTime.Now, ModPor = administrador, DataMod = DateTime.Now, Nome = "Rio Grande do Norte", UF = "RN" },
                new Estado() { IncPor = administrador, DataInc = DateTime.Now, ModPor = administrador, DataMod = DateTime.Now, Nome = "Rio Grande do Sul", UF = "RS" },
                new Estado() { IncPor = administrador, DataInc = DateTime.Now, ModPor = administrador, DataMod = DateTime.Now, Nome = "Rondônia", UF = "RO" },
                new Estado() { IncPor = administrador, DataInc = DateTime.Now, ModPor = administrador, DataMod = DateTime.Now, Nome = "Roraima", UF = "RR" },
                new Estado() { IncPor = administrador, DataInc = DateTime.Now, ModPor = administrador, DataMod = DateTime.Now, Nome = "Santa Catarina", UF = "SC" },
                new Estado() { IncPor = administrador, DataInc = DateTime.Now, ModPor = administrador, DataMod = DateTime.Now, Nome = "São Paulo", UF = "SP" },
                new Estado() { IncPor = administrador, DataInc = DateTime.Now, ModPor = administrador, DataMod = DateTime.Now, Nome = "Sergipe", UF = "SE" },
                new Estado() { IncPor = administrador, DataInc = DateTime.Now, ModPor = administrador, DataMod = DateTime.Now, Nome = "Tocantins", UF = "TO" }
            };

            context.Estados.AddRange(estados);
            context.SaveChanges();

        }
    }
}