using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSnippets
{
    internal class Empresa
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public Empleado[] Empleados { get; set; } = new Empleado[0];

        public override string ToString()
        {
            return Nombre;
        }
    }
}
