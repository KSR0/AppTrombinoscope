using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BddpersonnelContext
{
    public class bddpersonnels
    {
        private BddpersonnelDataContext bdd;

        public bddpersonnels(string addrIP, string utilisateur, string mdp, string port)
        {
            try
            {
                bdd = new BddpersonnelDataContext("User Id=" + utilisateur + ";Password=" + mdp + ";Host=" + addrIP + ";Port=" + port + ";Database=bddrationnel;Persist Security Info=True");
            } catch (Exception e)
            {
                throw e;
            }
        }
    }
}
