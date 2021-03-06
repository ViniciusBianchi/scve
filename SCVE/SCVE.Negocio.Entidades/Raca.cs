﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCVE.Negocio.Entidades
{
    public class Raca
    {
        public virtual int RacaId { get; set; }
        public virtual string Descricao { get; set; }

        #region Comparar Membros
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj == this)
                return true;

            if (!(obj is Raca))
                return false;

            Raca outro = (Raca)obj;
            return RacaId.Equals(outro.RacaId);
        }

        public override int GetHashCode()
        {
            return RacaId.GetHashCode();
        }
        #endregion Comparar Membros
    }
}
