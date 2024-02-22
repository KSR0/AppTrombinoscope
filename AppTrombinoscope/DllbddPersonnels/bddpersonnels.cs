using System;
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

        public List<Personnel> getAll()
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
    }
}
