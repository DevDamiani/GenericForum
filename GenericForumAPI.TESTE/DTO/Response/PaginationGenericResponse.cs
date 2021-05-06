using System;
using System.Collections.Generic;
using System.Text;

namespace GenericForum.Model.Response
{
    public class PaginationGenericResponse<T> 
    {
        
        public int Total { get; set; }
        public int TotalPaginas { get; set; }
        public int TamanhoPagina { get; set; }
        public int NumeroPagina{ get; set; }
        public IEnumerable<T> Value { get; set; }
        public string PreviousPage { get; set; }
        public string NextPage { get; set; }


        public PaginationGenericResponse()
        {

        }
        public PaginationGenericResponse(
            int total, int totalPaginas, int tamanhoPagina, int numeroPagina, IEnumerable<T> value, string previousPage, string nextPage)
        {
            Total = total;
            TotalPaginas = totalPaginas;
            TamanhoPagina = tamanhoPagina;
            NumeroPagina = numeroPagina;
            Value = value;
            PreviousPage = previousPage;
            NextPage = nextPage;
        }






    }
}
