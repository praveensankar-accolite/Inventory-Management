using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;

using Newtonsoft.Json;
using InventoryAPP.Controllers;

namespace InventoryManagementWEB.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RenderHome()
        {
            return View(); 
        }

        //MainManager
        public ActionResult MainManager()
        {
            return View();
        }

        public void GetHistoryDetails(string jsondata)
        {
            //dynamic DynamicObj = JsonConvert.DeserializeObject(obj);
            dynamic dynobj = JsonConvert.DeserializeObject(jsondata);
            //Object DynamicObj = JsonConvert.DeserializeObject(obj);
            string google = "http://www.google.co.in";
            string url = "http://localhost:49962/api/Tickets/GetTicket/1";
            
            //return Redirect("http://localhost:49962/api/Tickets/GetTicket/1");
            RedirectResult RR = Redirect(url);
            //Response.Redirect(url, true);
            //AR = RedirectToAction(url);
            //Uri uri;

            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(url);
            //client.Dispose();


            //function();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49962/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Main Code
                HttpResponseMessage response = client.GetAsync("api/Tickets/GetTicket/1").Result;
                if (response.IsSuccessStatusCode)
                {
                    dynamic product = response.Content.ReadAsAsync<dynamic>().Result;
                    //dynamic Result = product.Result;
                    string result = product.name;
                    //string str = product.foo;
                }
            }

            
            //InventoryAPP.Controllers.TicketsController Obj = new TicketsController();
            //Obj.GetTicket(1);
            RedirectToAction("Index", "Home");
            return;
            //return View();
        }

        public async void function()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49962/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Main Code
                HttpResponseMessage response = await client.GetAsync("api/Tickets/GetTicket/1");
                if (response.IsSuccessStatusCode)
                {
                    dynamic product = await response.Content.ReadAsAsync<dynamic>();
                    string str = product.msg;
                }
            }
        }
        // : Manager/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Manager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manager/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Manager/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Manager/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Manager/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Manager/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
