using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCVE.Negocio.Entidades
{
    public class Administrador
    {
        public virtual int AdministradorId { get; set; }
        public virtual String Email { get; set; }
        public virtual String Senha { get; set; }
        public virtual String Nome { get; set; }

        #region Comparar Membros
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj == this)
                return true;

            if (!(obj is Administrador))
                return false;

            Administrador outro = (Administrador)obj;
            return AdministradorId.Equals(outro.AdministradorId);
        }

        public override int GetHashCode()
        {
            return AdministradorId.GetHashCode();
        }
        #endregion Comparar Membros
    }
}
