using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Linq;

namespace teste.Controllers
{
    public class HomeController : Controller 
    {
        public ActionResult Index()
        {
            

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult SalvarFormulario(string nome, string email, string telefone, string mensagem)
        {
            DataContext db = new DataContext();
            
            //insert
            var obj = new Teste();
            obj.Nome = nome;
            obj.Email = email;
            obj.Telefone = telefone;
            obj.Mensagem = mensagem;

            db.Teste.InsertOnSubmit(obj);
            db.SubmitChanges();

            return RedirectToAction("message");
        }

        public ActionResult Message()
        {
            DataContext db = new DataContext();

            //consulta
            var consulta = db.Teste.ToList();

            return View(consulta);
        }

        public ActionResult Edit(int id)
        {
            //conexao
            DataContext db = new DataContext();

            //consulta
            var consulta = db.Teste.ToList();

            //update
            var atualizar = consulta.FirstOrDefault(c => c.Id == id);


            return View(atualizar);
        }

        [HttpPost]
        public ActionResult EditarFormulario(Teste model)
        {
            DataContext db = new DataContext();

            //insert
            var consulta = db.Teste.ToList();
            var obj = consulta.FirstOrDefault(c => c.Id == model.Id);
            obj.Nome = model.Nome;
            obj.Email = model.Email;
            obj.Telefone = model.Telefone;
            obj.Mensagem = model.Mensagem;

            //db.testes.InsertOnSubmit(obj);
            db.SubmitChanges();

            return RedirectToAction("message");
        }

        public ActionResult Details(Teste model)
        {
            DataContext db = new DataContext();

            //consulta
            var consulta = db.Teste.FirstOrDefault(c => c.Id == model.Id);

            return View(consulta);
        }

        public ActionResult Delete(Teste model)
        {
            DataContext db = new DataContext();

            //consulta
            var consulta = db.Teste.FirstOrDefault(c => c.Id == model.Id);

            //deletar
            var apagar = consulta;
            db.Teste.DeleteOnSubmit(apagar);
            db.SubmitChanges();

            return RedirectToAction("message");
        }
    }
}