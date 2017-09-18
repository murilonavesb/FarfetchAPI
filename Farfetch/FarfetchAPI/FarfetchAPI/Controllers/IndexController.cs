using FarfetchClass.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FarfetchClass.BLL;
using FarfetchClass.DAO;

namespace FarfetchAPI.Controllers
{
    /// <summary>
    /// API de Prescricao
    /// </summary>
    [RoutePrefix("api/toggle")]
    public class IndexController : ApiController
    {
        /// <summary>
        /// Method to return toggles
        /// </summary>
        /// <param name="idApplication">ID of the application</param>
        /// <param name="idVersion">ID of the version</param>
        /// <returns>Return toggles</returns>
        [HttpPost]
        [Route("GetToggle")]
        [ResponseType(typeof(string))]
        public IHttpActionResult GetToggles(int idApplication, int idVersion)
        {
            Toggle obj = new Toggle(idApplication, idVersion);
            return Ok(obj);
        }

        /// <summary>
        /// Method to set toggles
        /// </summary>
        /// <param name="idApplication">ID of the application</param>
        /// <param name="idVersion">ID of the version</param>
        /// <param name="strToggle">ID of the toggle</param>
        /// <param name="value">Value of the toggle</param>
        /// <returns>Return toggles</returns>
        [HttpPost]
        [Route("SetToggle")]
        [ResponseType(typeof(string))]
        public IHttpActionResult SetToggles(int idApplication, int idVersion, string strToggle, bool value)
        {
            //Create object
            Toggle obj = new Toggle();

            var objAux = obj.GetType().GetProperty(strToggle);

            if (objAux != null)
            {
                objAux.SetValue(obj, value);

                //Verify is existes key in database
                tabControlToggle objToggle = ControlToggleBLL.GetById(idApplication, idVersion, strToggle);
                bool bitInsert = false;

                //Create new object to insert or update in database
                if (objToggle == null)
                {
                    objToggle = new tabControlToggle();
                    bitInsert = true;
                }

                objToggle.idApplication = idApplication;
                objToggle.idVersion = idVersion;
                objToggle.strKey = strToggle;
                objToggle.strValue = value;

                if (bitInsert)
                {
                    ControlToggleBLL.Insert(objToggle);
                }
                else
                {
                    ControlToggleBLL.Update(objToggle);
                }
            }else
            {
                obj.msgError = "This property is not defined.";
            }

            return Ok(obj);
        }
    }
}
