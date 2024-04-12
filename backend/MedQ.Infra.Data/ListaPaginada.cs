using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Infra.Data
{
    public class ParametroPaginacao<T>
    {
        public int Primeiro { get; set; }
        public int Tamanho { get; set; }
        public string OrderBy { get; set; }
        public short Ordem { get; set; }

        public T Parametros { get; set; }

        public int PaginaAtual()
        {
            var aux = (Primeiro - 1) / Tamanho;
            return aux;
        }
    }

    [Serializable]
    public class ListaPaginada<T>
    {
        public List<T> Lista { get; set; }
        public int ContadorTotal { get; set; }

        public ListaPaginada()
        {
            
        }

        public ListaPaginada(List<T> collection)
        {
            this.Lista = collection;
            ContadorTotal = collection.Count;
        }
    }
}
