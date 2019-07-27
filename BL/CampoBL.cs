using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace BL
{
    public class CampoBL
    {


        public bool verificaData(string data) {
            try
            {
                
                if (data.Contains("—"))
                {
                    string dataAlterada=data.Replace("—", "-");
                    DateTime dt = DateTime.Parse(dataAlterada);
                    return true;
                }

                DateTime dtz = DateTime.Parse(data);
                return true;
            }
            catch
            {
                return false;
            }
        }

       public bool verificaNIF(string nif)
        {
            try
            {
                if (nif.Length == 9 && nif.All(Char.IsDigit))
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

        public bool verificaValorTotal(string valor)
        {

            try
            {

                string value = Regex.Replace(valor, "[A-Za-z ]", "");
                double parsedValue = double.Parse(value);
                float valorR;
                if (float.TryParse(value, out valorR))
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

        void verificaEntrada(string entrada)
        {
            if (true)
            {
                
            }

        }
    }
}
