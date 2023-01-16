using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarInsurance2.Models;

namespace CarInsurance2.Controllers
{
     
        public class AdminController : Controller
        {
            //GET: Admin
            public ActionResult Index()
            {
                using (InsuranceEntities db = new InsuranceEntities())//instantiate the entity object which gives access to the database
                {
                    var carsignups = db.CarSignUps; //var car = db.CarSignUps which represents all the records in the database 
                    var credentialsVms = new List<CredentialsVm>();//created new list of viewmodel to store values in to output to view
                    foreach (var credentials in carsignups)//gathers all information from db.CarSignUps
                    {
                        var credentialVm = new CredentialsVm();//each new object from type CVM which will hold all variables 
                        credentialVm.FirstName = credentials.FirstName;//var credentialVM assign to a new type which takes property
                        credentialVm.LastName = credentials.LastName;
                        credentialVm.EmailAddress = credentials.EmailAddress;
                        credentialVm.Quotes = credentials.Quotes;
                        credentialsVms.Add(credentialVm);//adds to list
                    }

                    return View(credentialsVms);//returns all necessary data to admin
                }
            }
            [HttpPost]
            public ActionResult DeleteConfirmed(int id)
            {
                using (InsuranceEntities db = new InsuranceEntities())
                {
                    var carsignup = db.CarSignUps.Find(id);
                    db.CarSignUps.Remove(id);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

        }
    }