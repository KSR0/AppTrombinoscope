using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
