using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassChasseurDT.Metier
{
    public class LoginEntreprise
    {
        public string UserIdent { get; set; }
        public string UserPwd { get; set; }

        public int IdEntreprise { get; set; }

        public LoginEntreprise()
        {

        }
        public override string ToString()
        {
            return base.ToString();
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(Object obj)
        {
            return obj is LoginEntreprise && ((LoginEntreprise)obj).IdEntreprise.Equals(this.IdEntreprise);
        }
    }
}
