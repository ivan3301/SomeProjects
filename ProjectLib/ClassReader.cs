using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectLib
{
    class ClassReader
    {
        private void HideBtn(Button btn_add, Button btn_del, Button btn_edit)
        {
            btn_add.Visible = false;
            btn_del.Visible = false;
            btn_edit.Visible = false;
        }
        public void getHideBtn(Button btn_add, Button btn_del, Button btn_edit)
        {
            HideBtn(btn_add, btn_del, btn_edit);
        }
    }
}
