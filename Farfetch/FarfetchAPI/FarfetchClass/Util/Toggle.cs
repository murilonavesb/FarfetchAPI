using FarfetchClass.BLL;
using FarfetchClass.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarfetchClass.Util
{
    public class Toggle
    {
        public bool isButtonBlue { get; set; }
        public bool isButtonGreen { get; set; }
        public bool isButtonRed { get; set; }
        public string msgError { get; set; }

        public Toggle()
        {

        }

        public Toggle(int idApplication, int idVersion)
        {
            //Set default properties
            //Application ID 1 = ABC
            if (idApplication == 1)
            {
                isButtonBlue = true;
                isButtonGreen = true;
                isButtonRed = false;
            }
            else
            {
                isButtonBlue = true;
                isButtonGreen = false;
                isButtonRed = true;
            }

            //Get property in database with ID Application and ID Version
            List<tabControlToggle> list = ControlToggleBLL.GetById(idApplication, idVersion);

            if(list != null && list.Count() > 0)
            {
                //Set new value in property
                foreach(tabControlToggle objAux in list)
                {
                    var objResult = this.GetType().GetProperty(objAux.strKey);
                    objResult.SetValue(this, objAux.strValue);
                }
            }
        }

    }
}
