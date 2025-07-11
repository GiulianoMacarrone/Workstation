using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{
    public static class Encriptacion
    {
        #region Métodos
        public static string EncriptarPassword(string pPassword)
        {
            try
            {
                byte[] encriptado = Encoding.Unicode.GetBytes(pPassword);
                string resultado = Convert.ToBase64String(encriptado);
                return resultado;
            }
            catch (CryptographicException ex)
            { throw ex; }
            catch (Exception ex) { throw ex; }
            finally { }
        }

        public static string DesencriptarPassword(this string pPasswordEncriptado)
        {
            try
            {
                byte[] desencriptar = Convert.FromBase64String(pPasswordEncriptado);
                string resultado = Encoding.Unicode.GetString(desencriptar);
                return resultado;
            }
            catch (CryptographicException ex) { throw ex;}
            catch (Exception ex) { throw ex; } finally { }

        }

        #endregion
    }
}
