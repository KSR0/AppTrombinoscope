﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devart.Data.MySql;

namespace BddpersonnelContext
{
    public class bddpersonnels
    {
        public BddpersonnelDataContext bdd;

        public bddpersonnels(string addrIP, string utilisateur, string mdp, string port)
        {
               bdd = new BddpersonnelDataContext("User Id=" + utilisateur + ";Password=" + mdp + ";Host=" + addrIP + ";Port=" + port + ";Database=bddpersonnels;Persist Security Info=True");
        }

        // Besoin pour verifier la connexion avec la bdd
        public List<Personnel> testerConnexion()
        {
            try
            {
                return bdd.Personnels.ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<Personnel> GetPersonnel()
        {
            try
            {
                return bdd.Personnels.ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<Service> GetServices()
        {
            try
            {
                return bdd.Services.ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<Fonction> GetFonctions()
        {
            try
            {
                return bdd.Fonctions.ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public bool GestionnaireExiste(string utilisateur, string mdp)
        {
            return bdd.Admins.Any(admin => admin.Nom == utilisateur && admin.Password == mdp);
        }


        public void AddPersonnel(string nom, string prenom, string telephone, byte[] blob, Service service, Fonction fonction)
        {
            Personnel personnel = new Personnel
            {
                Nom = nom,
                Prenom = prenom,
                Telephone = telephone,
                Photo = blob,
                Service = service,
                Fonction = fonction
            };

            bdd.Personnels.InsertOnSubmit(personnel);
            bdd.SubmitChanges();
        }

        public int SupprServices(Service item)
        {
            try
            {
                bdd.RejectChanges();
                bdd.Services.DeleteOnSubmit(item);
                bdd.SubmitChanges();
            }
            catch (MySqlException exception)
            {
                return -1;
            }
            catch (Exception exception)
            {
                return -1;
            }
            return 1;
        }

        public void AddServices(string nom)
        {
            try
            {
                Service item = new Service();
                item.Intitule = nom;
                bdd.RejectChanges();
                bdd.Services.InsertOnSubmit(item);
                bdd.SubmitChanges();
            }
            catch (MySqlException exception)
            {
                throw exception;
            }
        }

        public void UpdateServices(string nom, Service item)
        {
            try
            {
                bdd.RejectChanges();
                item.Intitule = nom;
                bdd.SubmitChanges();
            }
            catch (MySqlException exception)
            {
                throw exception;
            }
        }

        public int SupprFonctions(Fonction item)
        {
            try
            {
                bdd.RejectChanges();
                bdd.Fonctions.DeleteOnSubmit(item);
                bdd.SubmitChanges();
            }
            catch (MySqlException exception)
            {
                return -1;
            }
            catch (Exception exception)
            {
                return -1;
            }
            return 1;
        }

        public void AddFonctions(string nom)
        {
            try
            {
                Fonction item = new Fonction();
                item.Intitule = nom;
                bdd.RejectChanges();
                bdd.Fonctions.InsertOnSubmit(item);
                bdd.SubmitChanges();
            }
            catch (MySqlException exception)
            {
                throw exception;
            }
        }

        public void UpdateFonctions(string nom, Fonction item)
        {
            try
            {
                bdd.RejectChanges();
                item.Intitule = nom;
                bdd.SubmitChanges();
            }
            catch (MySqlException exception)
            {
                throw exception;
            }
        }
        public List<Personnel> GetPersonnelSearch(String txtNom, String txtPrenom, String txtservice, String txtFonction)
        {
            try
            {
                return bdd.Personnels.ToList().FindAll(x => string.IsNullOrEmpty(txtNom) ? true : x.Nom.ToUpper().Contains(txtNom.ToUpper()))
                    .FindAll( x => string.IsNullOrEmpty(txtPrenom) ? true : x.Prenom.ToUpper().Contains(txtPrenom.ToUpper()))
                    .FindAll( x => string.IsNullOrEmpty(txtservice) ? true : x.Service.Intitule.ToUpper().Contains(txtservice.ToUpper()))
                    .FindAll( x => string.IsNullOrEmpty(txtFonction) ? true : x.Fonction.Intitule.ToUpper().Contains(txtFonction.ToUpper()));
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
