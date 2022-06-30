using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ApiConta.Models;
using System.Data.Entity;

namespace ApiConta.Controllers
{
    public class ContaController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetConta()
        {
            IList<Conta> contas = null;
            using (var ctx = new AppDbContext())
            {
                contas = ctx.Contas.Select(s => new Conta()
                            {
                                Nome = s.Nome,
                                Descricao = s.Descricao
                            }).ToList();
            }
            if (contas.Count == 0)
            {
                return NotFound();
            }
            return Ok(contas);
        }

        public IHttpActionResult PostNovaConta(Conta conta)
        {
            if (!ModelState.IsValid || conta == null)
                return BadRequest("Dados da Conta inválidos.");
            using (var ctx = new AppDbContext())
            {
                ctx.Contas.Add(new Conta()
                {
                    Nome = conta.Nome,
                    Descricao = conta.Descricao
                });
                ctx.SaveChanges();
            }
            return Ok(conta);
        }

        public IHttpActionResult Put(Conta conta)
        {
            if (!ModelState.IsValid || conta == null)
                return BadRequest("Dados da Conta inválidos");
            using (var ctx = new AppDbContext())
            {
                var contaSelecionado = ctx.Contas.Where(c => c.Nome == conta.Nome)
                                                           .FirstOrDefault<Conta>();
                if (contaSelecionado != null)
                {
                    contaSelecionado.Nome = conta.Nome;
                    contaSelecionado.Descricao = conta.Descricao;
                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok($"Conta {conta.Nome} atualizado com sucesso");
        }

        public IHttpActionResult Delete(string nomeconta)
        {
            if (nomeconta == null)
                return BadRequest("Dados inválidos");
            using (var ctx = new AppDbContext())
            {
                var contaSelecionado = ctx.Contas.Where(c => c.Nome == nomeconta)
                                            .FirstOrDefault<Conta>() ;

                if (contaSelecionado != null)
                {
                    ctx.Entry(contaSelecionado).State = EntityState.Deleted;
                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok($"Conta {nomeconta} foi deletado com sucesso");
        }

    }
}
