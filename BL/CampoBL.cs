using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    class CampoBL
    {


        bool verificaData(string data) {
            try
            {
                DateTime dt = DateTime.Parse(data);
                return true;
            }
            catch
            {
                return false;
            }
        }

       bool verificaNIF(string nif)
        {
            try
            {
                if (nif.Length== 9 && nif.Contains("[0-9]+"))
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
                throw;
            }
        }

        bool verificaValorTotal(string valor)
        {
            try
            {
                float valorR;
                if (float.TryParse(valor, out valorR))
                {
                    return true;
                }
                return false;
            }
            catch
            {

                throw;
            }
        }

        void verificaEntrada(string entrada)
        {
            if (true)
            {
                
            }

        }
    }
}
