using System;
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
                item.Intitule = nom;
                bdd.SubmitChanges();
            }
            catch (MySqlException exception)
            {
                throw exception;
            }
        }
    }
}
