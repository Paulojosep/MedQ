using System.Collections.Generic;

namespace MedQ.Domain.Entities
{
    public class Especialidade : Entity
    {
        public Especialidade()
        {
            Filas = new HashSet<Fila>();
            Medicos = new HashSet<Medico>();
        }

        public string Nome { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Fila> Filas { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
