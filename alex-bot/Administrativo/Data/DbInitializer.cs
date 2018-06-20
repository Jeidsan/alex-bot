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

            // Adicionando Administradores
            var administrador = new Administrador() { Nome = "Joao da Silva", Login = "joao.silva", Senha = "123" };   
            var administradores = new Administrador[]
            {
                administrador,
                new Administrador() { Nome = "Jorge Paulo Lacerda", Login = "jorge.lacerda", Senha = "123" }
            };
            context.Administradores.AddRange(administradores);
            context.SaveChanges();

            // Adicionando os Temas
            var tema = new Tema() { IncPor = administrador, DataInc = new DateTime(2018, 1, 1), ModPor = administrador, DataMod = new DateTime(2018, 1, 1), Nome = "Infecção", Descricao = "Infecções Sexualmente Transmissíveis" };
            var temas = new Tema[]
            {
                tema,
                new Tema() { IncPor = administrador, DataInc = new DateTime(2018,1,1), ModPor = administrador, DataMod = new DateTime(2018,1,1), Nome = "Tratamento", Descricao = "Infecções Sexualmente Transmissíveis" },
                new Tema() { IncPor = administrador, DataInc = new DateTime(2018,1,1), ModPor = administrador, DataMod = new DateTime(2018,1,1), Nome = "Contracepção", Descricao = "Infecções Sexualmente Transmissíveis" }
            };
            context.Temas.AddRange(temas);
            context.SaveChanges();

            // Adicionando as Perguntas
            var pergunta = new Pergunta() { IncPor = administrador, DataInc = new DateTime(2018, 1, 1), ModPor = administrador, DataMod = new DateTime(2018, 1, 1), Descricao = "Pergunta 1", Tema = tema };
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
                new Resposta() { IncPor = administrador, DataInc = new DateTime(2018, 1, 1), ModPor = administrador, DataMod = new DateTime(2018, 1, 1), Descricao = "Resposta 1", Pergunta = pergunta }
            };
            context.Respostas.AddRange(respostas);
            context.SaveChanges();

        }
    }
}
