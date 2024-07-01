using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InsertarPersonasCapTemp
{
    public class UtilMail
    {
        public void EnviarMail(Exception excepcion)
        {
            string mailServerIp = GetDatosSettingByKey("IpMail");
            string User = GetDatosSettingByKey("EmailUser");
            string Pass = GetDatosSettingByKey("EmailPass");

            MailMessage email = new MailMessage();
            email.IsBodyHtml = true;
            email.From = new MailAddress("aviso@reportv.com.ar", "Control de Procesos", Encoding.UTF8);

            SmtpClient SmtpServer = new SmtpClient(mailServerIp);
            SmtpServer.Port = 25;
            SmtpServer.Credentials = new System.Net.NetworkCredential(User, Pass);

            email.Subject = "[ERROR] - Proceso Insertar Personas en Capitulos y Temporadas";

            string direccion = GetDatosSettingByKey("Correos");
            string[] dir = direccion.Split('|');
            foreach (string d in dir)
            {
                email.To.Add(d);
            }

            email.Body = "Se produjo un error fatal en la aplicación. " + Environment.NewLine + excepcion.Message + Environment.NewLine + excepcion.StackTrace;

            SmtpServer.Send(email);
            Thread.Sleep(3000);
        }

        public void EnviarMail(List<InfoMail> procesosAndTiempos)
        {
            string mailServerIp = GetDatosSettingByKey("IpMail");
            string User = GetDatosSettingByKey("EmailUser");
            string Pass = GetDatosSettingByKey("EmailPass");

            MailMessage email = new MailMessage();
            email.IsBodyHtml = true;
            email.From = new MailAddress("aviso@reportv.com.ar", "Control de Procesos", Encoding.UTF8);

            SmtpClient SmtpServer = new SmtpClient(mailServerIp);
            SmtpServer.Port = 25;
            SmtpServer.Credentials = new System.Net.NetworkCredential(User, Pass);

            email.Subject = "[OK] - Proceso Insertar Personas en Capitulos y Temporadas";

            string direccion = GetDatosSettingByKey("Correos");
            string[] dir = direccion.Split('|');
            foreach (string d in dir)
            {
                email.To.Add(d);
            }

            email.Body = CrearTabla(procesosAndTiempos);

            SmtpServer.Send(email);
            Thread.Sleep(3000);
        }

        private string CrearTabla (List<InfoMail> procesosAndTiempos)
        {
            StringBuilder myBuilder = new StringBuilder();

            myBuilder.Append("<html xmlns='http://www.w3.org/1999/xhtml'>");
            myBuilder.Append("<head>");
            myBuilder.Append("<title>");
            myBuilder.Append("Page-");
            myBuilder.Append(Guid.NewGuid().ToString());
            myBuilder.Append("</title>");
            myBuilder.Append("</head>");
            myBuilder.Append("<body>");

            myBuilder.Append("<table border='2' bordercolor=black cellpadding='10' cellspacing='0' style='border: solid 2px black;'>");

            myBuilder.Append("<tr align='center' valign='top' font-size=large bgcolor=#51bd58 style='font-size: medium;>");

            myBuilder.Append("<td align='center' valign='top'>");
            myBuilder.Append("<b>Proceso</b>");
            myBuilder.Append("</td>");

            myBuilder.Append("<td align='center' valign='top'>");
            myBuilder.Append("<b>Personas</b>");
            myBuilder.Append("</td>");

            myBuilder.Append("<td align='center' valign='top'>");
            myBuilder.Append("<b>Inicio</b>");
            myBuilder.Append("</td>");

            myBuilder.Append("<td align='center' valign='top'>");
            myBuilder.Append("<b>Finalización</b>");
            myBuilder.Append("</td>");

            myBuilder.Append("<td align='center' valign='top'>");
            myBuilder.Append("<b>Duración</b>");
            myBuilder.Append("</td>");

            myBuilder.Append("</tr>");

            for (int i = 0; i < procesosAndTiempos.Count; i++)
            {
                myBuilder.Append("<tr align='left' valign='top' bgcolor=#9bd9cd>");

                myBuilder.Append("<td align='left' valign='top'>");
                myBuilder.Append(procesosAndTiempos[i].NombreProceso);
                myBuilder.Append("</td>");

                myBuilder.Append("<td align='left' valign='top'>");
                myBuilder.Append(procesosAndTiempos[i].PersonasProcesadas);
                myBuilder.Append("</td>");

                myBuilder.Append("<td align='left' valign='top'>");
                myBuilder.Append(procesosAndTiempos[i].FechaInicio);
                myBuilder.Append("</td>");

                myBuilder.Append("<td align='left' valign='top'>");
                myBuilder.Append(procesosAndTiempos[i].FechaFinalizacion);
                myBuilder.Append("</td>");

                myBuilder.Append("<td align='left' valign='top'>");
                myBuilder.Append(procesosAndTiempos[i].Duracion);
                myBuilder.Append("</td>");

                myBuilder.Append("</tr>");
            }

            myBuilder.Append("</table>");
            myBuilder.Append("</body>");
            myBuilder.Append("</html>");

            return myBuilder.ToString();
        }

        private string GetDatosSettingByKey(string key)
        {
            try
            {
                return System.Configuration.ConfigurationManager.AppSettings[key] ?? "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
